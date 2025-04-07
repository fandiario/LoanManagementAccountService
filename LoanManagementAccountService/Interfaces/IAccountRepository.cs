using LoanManagementAccountService.Models;
using Microsoft.AspNetCore.Identity;

namespace LoanManagementAccountService.Interfaces
{
    public interface IAccountRepository
    {
        Task<bool> RegisterUserAsync(AccountModel.RegisterModel account);

        Task<AccountModel> FindByUsernameAsync(string username);

        Task<bool> CheckPasswordAsync(AccountModel account, string password);
    }
}
