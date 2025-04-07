using LoanManagementAccountService.Data;
using LoanManagementAccountService.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

public static class RoleSeeder
{
    public static async Task SeedRolesAsync(IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        if (!await db.Roles.AnyAsync())
        {
            var json = File.ReadAllText("Seeds/RoleSeed.json");
            var roles = JsonSerializer.Deserialize<List<RoleModel>>(json);

            db.Roles.AddRange(roles);
            await db.SaveChangesAsync();
        }
    }
}
