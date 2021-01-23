            // add User Manager related objects into DI configuration
            services.AddTransient<IUserStore<User>, UserStore<User, IdentityRole<string>, ApplicationDbContext>>();
            services.AddTransient<IRoleStore<IdentityRole<string>>, RoleStore<IdentityRole<string>, ApplicationDbContext>>();
            services.AddTransient<IPasswordHasher<User>, PasswordHasher<User>>();
            services.AddTransient<ILookupNormalizer, UpperInvariantLookupNormalizer>();
            services.AddTransient<IdentityErrorDescriber>();
            var identityBuilder = new IdentityBuilder(typeof(User), typeof(IdentityRole<string>), services);
            identityBuilder.AddTokenProvider("Default", typeof(DataProtectorTokenProvider<User>));
            services.AddTransient<UserManager<User>>();
