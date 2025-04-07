using LoanManagementAccountService.Data;
using LoanManagementAccountService.Interfaces;
using LoanManagementAccountService.Models;
using Microsoft.AspNetCore.Identity;

namespace LoanManagementAccountService.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<AccountModel> _userManager;
        private readonly ApplicationDbContext _context;


        public AccountRepository( UserManager<AccountModel> userManager, ApplicationDbContext context)
        {

            
            _userManager = userManager;
            _context = context;
        }
        public async Task<bool> RegisterUserAsync(AccountModel.RegisterModel model)
        {
            var account = new AccountModel
            {
                UserName = model.Username,
                Email = model.Email,
                IdRole = model.IdRole
            };

            var result = await _userManager.CreateAsync(account, model.Password);

            return result.Succeeded;
        }

        public async Task<AccountModel> FindByUsernameAsync(string username)
        {
            return await _userManager.FindByNameAsync(username);
        }

        public async Task<bool> CheckPasswordAsync(AccountModel user, string password)
        {
            return await _userManager.CheckPasswordAsync(user, password);
        }
    }
}
