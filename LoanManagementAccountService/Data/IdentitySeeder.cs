using LoanManagementAccountService.Models;
using LoanManagementAccountService;
using Microsoft.AspNetCore.Identity;
using System.Text.Json;

public static class IdentitySeeder
{
    public static async Task SeedUsersAsync(IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AccountModel>>();

        if (!userManager.Users.Any())
        {
            var json = File.ReadAllText("../Data/Seeds/AccountSeeds.json");
            var seedUsers = JsonSerializer.Deserialize<List<AccountSeedsModel>>(json);

            foreach (var seedUser in seedUsers)
            {
                var user = new AccountModel
                {
                    UserName = seedUser.Username,
                    Email = seedUser.Email,
                    IdRole = seedUser.IdRole,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(user, seedUser.Password);

                if (!result.Succeeded)
                {
                    throw new Exception($"Failed to create user {seedUser.Username}: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                }
            }
        }
    }
}