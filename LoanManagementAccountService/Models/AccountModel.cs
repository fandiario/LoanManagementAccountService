using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanManagementAccountService.Models
{
    //[Table("MasterUser")]
    public class AccountModel : IdentityUser
    {
        public int IdRole { get; set; }
        public class RegisterModel
        {
            public string Username { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public int IdRole { get; set; }
        }

        public class LoginModel
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        public class AccountUserModel
        {
            public int Id { get; set; }
            public string Username { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public int IdRole { get; set; }
        }
    }
}
