    services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                    .AddJsonOptions(options => {
                        var resolver = options.SerializerSettings.ContractResolver;
                        if (resolver != null)
                            (resolver as DefaultContractResolver).NamingStrategy = null;
                    });
    
                services.AddDbContext<PaymentDetailContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DevConnection"))); //Dependency Injection
                // options => options.UseSqlServer() Lamda Expression
    
                services.AddCors(options =>
                {
                    options.AddPolicy(MyAllowSpecificOrigins,
                        builder =>
                        {
                            builder.WithOrigins("http://localhost:4200").AllowAnyHeader()
                                    .AllowAnyMethod(); ;
                        });
                });
