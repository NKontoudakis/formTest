using FormTest.DataAccess.Models; // Keeps us connected to your data structure
using Microsoft.AspNetCore.Identity;

namespace FormTest.WebApp.Helpers
{
    public static class DbSeeder
    {
        // This is the main method we will call from Program.cs
        public static async Task SeedRolesAndAdminAsync(IServiceProvider service)
        {
            // 1. Grab the necessary tools from the "toolbox" (ServiceProvider)
            var userManager = service.GetService<UserManager<IdentityUser>>();
            var roleManager = service.GetService<RoleManager<IdentityRole>>();

            // 2. Create Roles (The Badges)
            await CreateRoleAsync(roleManager, "Admin");
            await CreateRoleAsync(roleManager, "Viewer");

            // 3. Create the Admin User (The Person)
            var adminEmail = "n.kontoudakis@mainsys.eu";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                var newAdmin = new IdentityUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true,
                };

                // Create the user with a specific password
                await userManager.CreateAsync(newAdmin, "xdR5$#@!");

                // Assign the "Admin" badge to this user
                await userManager.AddToRoleAsync(newAdmin, "Admin");
            }

            var viewerEmail = "niko.ss@windowslive.com";
            var viewerUser = await userManager.FindByEmailAsync(viewerEmail);

            if (viewerUser == null)
            {
                var newViewer = new IdentityUser
                {
                    UserName = viewerEmail,
                    Email = viewerEmail,
                    EmailConfirmed = true,
                };

                await userManager.CreateAsync(newViewer, "xdR5$#@!");
                await userManager.AddToRoleAsync(newViewer, "Viewer");
            }
        }

        // A small helper to keep the code clean
        private static async Task CreateRoleAsync(
            RoleManager<IdentityRole> roleManager,
            string roleName
        )
        {
            // Only create the role if it doesn't exist yet
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }
    }
}
