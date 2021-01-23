    services.AddAuthentication(options =>
      {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      })
      .AddJwtBearer((Action<JwtBearerOptions>)(options =>
      {
        options.TokenValidationParameters =
            new TokenValidationParameters
            {
              LifetimeValidator = (before, expires, token, param) =>
                       {
                         return expires > DateTime.UtcNow;
                       },
              IssuerSigningKey = JwtSettings.SecurityKey,
              ValidIssuer = JwtSettings.TOKEN_ISSUER,
              ValidateIssuerSigningKey = true,
              ValidateIssuer = true,
              ValidateAudience = false,
              NameClaimType = GGClaimTypes.NAME
            };
        options.Events = new JwtBearerEvents
        {
          OnMessageReceived = mrCtx =>
          {
            // Look for HangFire stuff
            var path = mrCtx.Request.Path.HasValue ? mrCtx.Request.Path.Value : "";
            var pathBase = mrCtx.Request.PathBase.HasValue ? mrCtx.Request.PathBase.Value : path;
            var isFromHangFire = path.StartsWith(WebsiteConstants.HANG_FIRE_URL) || pathBase.StartsWith(WebsiteConstants.HANG_FIRE_URL);
            //If it's HangFire look for token.
            if (isFromHangFire)
            {
              if (mrCtx.Request.Query.ContainsKey("tkn"))
              {
                //If we find token add it to the response cookies
                mrCtx.Token = mrCtx.Request.Query["tkn"];
                mrCtx.HttpContext.Response.Cookies
                .Append("HangFireCookie",
                    mrCtx.Token,
                    new CookieOptions()
                    {
                      Expires = DateTime.Now.AddMinutes(10)
                    });
              }
              else
              {
                //Check if we have a cookie from the previous request.
                var cookies = mrCtx.Request.Cookies;
                if (cookies.ContainsKey("HangFireCookie"))
                  mrCtx.Token = cookies["HangFireCookie"];                
              }//Else
            }//If
            return Task.CompletedTask;
          }
        };
      })); 
