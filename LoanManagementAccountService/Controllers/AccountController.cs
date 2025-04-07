using LoanManagementAccountService.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using static LoanManagementAccountService.Models.AccountModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LoanManagementAccountService.Interfaces;

namespace LoanManagementAccountService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<AccountModel> _userManager;
        private readonly SignInManager<AccountModel> _signInManager;

        private readonly IAccountService _accountService;


        public AccountController(IAccountService accountService, IConfiguration configuration)
        {
            _accountService = accountService;
            _configuration = configuration;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var result = await _accountService.RegisterUserAsync(model);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(new { Message = result.Message });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var result = await _accountService.LoginAsync(model);

            if (!result.Success)
                return Unauthorized();

            return Ok(new { Token = result.Token });
        }

    }
}
