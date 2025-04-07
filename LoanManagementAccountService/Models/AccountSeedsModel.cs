using System.ComponentModel.DataAnnotations.Schema;

namespace LoanManagementAccountService.Models
{
    [Table("MasterUser")]
    public class AccountSeedsModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int IdRole { get; set; }
    }
}
