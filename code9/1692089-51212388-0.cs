            services.AddDbContext<AuthenticDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ConnectionString")));
            services.AddIdentity<AplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<AuthenticDBContext>()
                .AddDefaultTokenProviders();
            services.AddMvc().AddJsonOptions(configureJson);
        }
