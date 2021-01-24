      services.AddAuthentication(opt => {
                    opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    //options.Audience = "http://localhost:13818/";
                    //options.Authority = "http://localhost:13818/";                
                    options.TokenValidationParameters = new 
                    TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("iNivDmHLpUA223sqsfhqGbMRdRj1PVkH")),
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true
                    };
                }); 
 
