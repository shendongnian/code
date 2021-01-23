    services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                 .AddJwtBearer(cfg =>
                 {
                     cfg.RequireHttpsMetadata = false;
                     cfg.SaveToken = true;
                     cfg.TokenValidationParameters = new TokenValidationParameters()
                     {
                         //ValidateIssuerSigningKey = true,
                         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Encryptionkey"])),
                         ValidateAudience = false,
                         ValidateLifetime = true,
                         ValidIssuer = configuration["Jwt:Issuer"],
                         //ValidAudience = Configuration["Jwt:Audience"],
                         //IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Key"])),
                     };
                 });
