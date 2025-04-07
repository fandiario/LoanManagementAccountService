using LoanManagementAccountService.Interfaces;
using LoanManagementAccountService.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static LoanManagementAccountService.Models.AccountModel;

namespace LoanManagementAccountService.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IConfiguration _configuration;

        public AccountService(IAccountRepository accountRepository, IConfiguration configuration)
        {
            _accountRepository = accountRepository;
            _configuration = configuration;
        }
        public async Task<(bool Success, string Message)> RegisterUserAsync(RegisterModel account)
        {
            var user = new RegisterModel { Username = account.Username, Email = account.Email , Password = account.Password, IdRole = account.IdRole };
            var result = await _accountRepository.RegisterUserAsync(user);

            if (!result)
                return (false, "User registration failed");

            return (true, "User registered successfully!");
        }

        public async Task<(bool Success, string? Token)> LoginAsync(LoginModel model)
        {
            var user = await _accountRepository.FindByUsernameAsync(model.Username);
            
            if (user == null || !await _accountRepository.CheckPasswordAsync(user, model.Password))
            {
                return (false, null);
            }

            var token = GenerateJwtToken(user);
            return (true, token);
        }

        private string GenerateJwtToken(AccountModel user)
        {
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(7),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
