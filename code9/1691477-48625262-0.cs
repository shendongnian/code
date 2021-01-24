        services                
            .AddOAuth("QuickBooks", options =>
            {
                options.ClientId = Configuration["QuickBooks:ClientId"];
                options.ClientSecret = Configuration["QuickBooks:ClientSecret"];
                options.CallbackPath = new PathString("/QuickBooks/Authorize");
                options.AuthorizationEndpoint = Configuration["QuickBooks:AuthorizationEndpoint"];
                options.TokenEndpoint = Configuration["QuickBooks:TokenEndpoint"];
                options.UserInformationEndpoint = Configuration["QuickBooks:UserInformationEndpoint"];
                options.Scope.Add("com.intuit.quickbooks.accounting");
                options.Scope.Add("com.intuit.quickbooks.payment");
                options.SaveTokens = true;
                options.Events = new OAuthEvents
                {
                    OnCreatingTicket = async context =>
                    {
                        var resp = JsonConvert.DeserializeObject<QuickbooksAuthSettings>(context.TokenResponse.Response.ToString());
                        resp.AuthorizationCode = context.Request.Query["code"].ToString();
                        resp.RealmId = context.Request.Query["realmId"].ToString();
                        TimeSpan tsAccessToken;
                        if (TimeSpan.TryParse(resp.AccessTokenExpireStr, out tsAccessToken))
                            resp.AccessTokenExpire = DateTime.UtcNow.Add(tsAccessToken);
                        resp.RefreshTokenExpire = DateTime.UtcNow.AddSeconds(Convert.ToInt64(resp.RefreshTokenExpireStr));
                        var opts = new DbContextOptionsBuilder<AppDbContext>();
                        opts.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                        var qbService = new QuickBooksService(this.Configuration, new AppDbContext(opts.Options));
                        qbService.SaveToken(resp);
                    }
                };
            });
