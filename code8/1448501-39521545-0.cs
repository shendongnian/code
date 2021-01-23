            // Add the Admin role to the database
            IdentityResult roleResult;
            bool adminRoleExists = await _roleManager.RoleExistsAsync("Admin");
            if (!adminRoleExists)
            {
                _logger.LogInformation("Adding Admin role");
                roleResult = await _roleManager.CreateAsync(new IdentityRole("Admin"));
            }
            // Select the user, and then add the admin role to the user
            ApplicationUser user = await _userManager.FindByNameAsync("sysadmin");
            if (!await _userManager.IsInRoleAsync(user, "Admin"))
            {
                _logger.LogInformation("Adding sysadmin to Admin role");
                var userResult = await _userManager.AddToRoleAsync(user, "Admin");
            }
