using LoanManagementAccountService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace LoanManagementAccountService.Data
{
    public class ApplicationDbContext: IdentityDbContext<AccountModel>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<AccountModel> Accounts { get; set; }

        public DbSet<RoleModel> Roles { get; set; }
    }
}
