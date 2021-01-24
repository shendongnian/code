    services.AddAuthentication()
      .AddJwtBearer(cfg =>
      {
        cfg.RequireHttpsMetadata = false;
        cfg.SaveToken = true;
        
        cfg.TokenValidationParameters = new TokenValidationParameters()
        {
          ValidIssuer = Configuration["Tokens:Issuer"],
          ValidAudience = Configuration["Tokens:Issuer"],
          IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"]))
        };
    
      });
