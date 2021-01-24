     public void ConfigureServices(IServiceCollection services)
            {               
                //====================================================
                // Create the DB context for the IDENTITY database
                //====================================================
                // Add a database context - this can be instantiated with no parameters
                services.AddTransient(typeof(ApplicationDbContext));
    
                //====================================================
                // ApplicationUserManager
                //====================================================
                // instantiation requires the following instance of the Identity database
                services.AddTransient(typeof(IUserStore<ApplicationUser>), p => new UserStore<ApplicationUser>(new ApplicationDbContext()));
    
                // with the above defined, we can add the user manager class as a type
                services.AddTransient(typeof(ApplicationUserManager));
    
                //====================================================
                // ApplicationSignInManager
                //====================================================
                // instantiation requires two parameters, [ApplicationUserManager] (defined above) and [IAuthenticationManager]
                services.AddTransient(typeof(Microsoft.Owin.Security.IAuthenticationManager), p => new OwinContext().Authentication);
                services.AddTransient(typeof(ApplicationSignInManager));
    
                //====================================================
                // ApplicationRoleManager
                //====================================================
                // Maps the rolemanager of identity role to the concrete role manager type
                services.AddTransient<RoleManager<IdentityRole>, ApplicationRoleManager>();
    
                // Maps the role store role to the implemented type
                services.AddTransient<IRoleStore<IdentityRole, string>, RoleStore<IdentityRole>>();
                services.AddTransient(typeof(ApplicationRoleManager));
                
                //====================================================
                // Add all controllers as services
                //====================================================
                services.AddControllersAsServices(typeof(Startup).Assembly.GetExportedTypes()
                    .Where(t => !t.IsAbstract && !t.IsGenericTypeDefinition)
                .Where(t => typeof(IController).IsAssignableFrom(t)
                || t.Name.EndsWith("Controller", StringComparison.OrdinalIgnoreCase)));
            }
