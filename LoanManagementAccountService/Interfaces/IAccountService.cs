using Microsoft.AspNetCore.Identity;
using static LoanManagementAccountService.Models.AccountModel;

namespace LoanManagementAccountService.Interfaces
{
    public interface IAccountService
    {
        Task<(bool Success, string Message)> RegisterUserAsync(RegisterModel account);

        Task<(bool Success, string? Token)> LoginAsync(LoginModel model);
    }
}
