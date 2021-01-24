    services.AddAuthentication(   // no Authenticationschemes mentioned here  )
                    .AddCookie() //CookieAuthentication
                    .AddJwtBearer(options =>
                    {
                        options.Audience = "xyz";
                        options.Authority = "yzx";
                    });
