     services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters =
                            new TokenValidationParameters
                            {
                                ValidateIssuer = true,
                                ValidateAudience = true,
                                ValidateLifetime = true,
                                ValidateIssuerSigningKey = true,
                                ValidIssuer = TokenConstants.ValidIssuer,
                                ValidAudience = TokenConstants.ValidAudience,
                                IssuerSigningKey = JwtSecurityKey.Create(TokenConstants.IssuerSigningKey),
                                
                            };
                    });
