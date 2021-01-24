        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IServiceProvider serviceProvider)
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
            CreateRoles(serviceProvider);
        }
        private void CreateRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            Task<IdentityResult> roleResult;
            string email = "someone@somewhere.com";
            //Check that there is an Administrator role and create if not
            Task<bool> hasAdminRole = roleManager.RoleExistsAsync("Administrator");
            hasAdminRole.Wait();
            if (!hasAdminRole.Result)
            {
                roleResult = roleManager.CreateAsync(new IdentityRole("Administrator"));
                roleResult.Wait();
            }
            //Check if the admin user exists and create it if not
            //Add to the Administrator role
            Task<ApplicationUser> testUser = userManager.FindByEmailAsync(email);
            testUser.Wait();
            if (testUser.Result == null)
            {
                ApplicationUser administrator = new ApplicationUser();
                administrator.Email = email;
                administrator.UserName = email;
                Task<IdentityResult> newUser = userManager.CreateAsync(administrator, "_AStrongP@ssword!");
                newUser.Wait();
                if (newUser.Result.Succeeded)
                {
                    Task<IdentityResult> newUserRole = userManager.AddToRoleAsync(administrator, "Administrator");
                    newUserRole.Wait();
                }
            }
        }
