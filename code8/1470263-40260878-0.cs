              services.AddDbContext<ApplicationDbContext>(
                options =>
                    options.UseSqlServer(
                        configuration["Data:DefaultConnection:ConnectionString"], b =>
                                b.MigrationsAssembly("MyProj.Web"))
