using System.ComponentModel.DataAnnotations.Schema;

namespace LoanManagementAccountService.Models
{
    [Table("MasterRole")]
    public class RoleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
