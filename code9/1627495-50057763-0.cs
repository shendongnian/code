        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddAuthentication()
                .AddCookie()
                .AddGoogle(options =>
                {
                    options.ClientId = Configuration["Google.LoginProvider.ClientId"];
                    options.ClientSecret = Configuration["Google.LoginProvider.ClientKey"];
                    options.Scope.Add("profile");
                    options.Events.OnCreatingTicket = (context) =>
                    {
                        context.Identity.AddClaim(new Claim("image", context.User.GetValue("image").SelectToken("url").ToString()));
                        return Task.CompletedTask;
                    };
                });
        }
