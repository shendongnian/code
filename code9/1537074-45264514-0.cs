        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, 
            IServiceProvider serviceProvider)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            app.UseIdentity();
            // Add external authentication middleware below. To configure them please see https://go.microsoft.com/fwlink/?LinkID=532715
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            CreateRolesAndAdminUser(serviceProvider);
        }
		
		private static void CreateRolesAndAdminUser(IServiceProvider serviceProvider)
        {
            const string adminRoleName = "Administrator";
            string[] roleNames = { adminRoleName, "Manager", "Member" };
            foreach (string roleName in roleNames)
            {
                CreateRole(serviceProvider, roleName);
            }
            // Get these value from "appsettings.json" file.
            string adminUserEmail = "someone22@somewhere.com";
            string adminPwd = "_AStrongP1@ssword!";
            AddUserToRole(serviceProvider, adminUserEmail, adminPwd, adminRoleName);
        }
        /// <summary>
        /// Create a role if not exists.
        /// </summary>
        /// <param name="serviceProvider">Service Provider</param>
        /// <param name="roleName">Role Name</param>
        private static void CreateRole(IServiceProvider serviceProvider, string roleName)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            Task<bool> roleExists = roleManager.RoleExistsAsync(roleName);
            roleExists.Wait();
            
            if (!roleExists.Result)
            {
                Task<IdentityResult> roleResult = roleManager.CreateAsync(new IdentityRole(roleName));
                roleResult.Wait();
            }
        }
        /// <summary>
        /// Add user to a role if the user exists, otherwise, create the user and adds him to the role.
        /// </summary>
        /// <param name="serviceProvider">Service Provider</param>
        /// <param name="userEmail">User Email</param>
        /// <param name="userPwd">User Password. Used to create the user if not exists.</param>
        /// <param name="roleName">Role Name</param>
        private static void AddUserToRole(IServiceProvider serviceProvider, string userEmail, 
            string userPwd, string roleName)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            Task<ApplicationUser> checkAppUser = userManager.FindByEmailAsync(userEmail);
            checkAppUser.Wait();
            ApplicationUser appUser = checkAppUser.Result;
            if (checkAppUser.Result == null)
            {
                ApplicationUser newAppUser = new ApplicationUser
                {
                    Email = userEmail,
                    UserName = userEmail
                };
                
                Task<IdentityResult> taskCreateAppUser = userManager.CreateAsync(newAppUser, userPwd);
                taskCreateAppUser.Wait();
                if (taskCreateAppUser.Result.Succeeded)
                {
                    appUser = newAppUser;
                }
            }
            Task<IdentityResult> newUserRole = userManager.AddToRoleAsync(appUser, roleName);
            newUserRole.Wait();
        }
