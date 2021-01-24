    public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            services.AddAuthentication().AddFacebook(facebookOptions =>
            {
                facebookOptions.AppId = Configuration["Settings:Authentication:Facebook:AppId"];
                facebookOptions.AppSecret = Configuration["Settings:Authentication:Facebook:AppSecret"];
                facebookOptions.SaveTokens = true;
                facebookOptions.Scope.Add("gender");
                facebookOptions.Scope.Add("email");
                facebookOptions.Scope.Add("public_profile");
                facebookOptions.Scope.Add("user_birthday");
                //facebookOptions.UserInformationEndpoint = "https://graph.facebook.com/v2.5/me?fields=id,name,email";
                //facebookOptions.BackchannelHttpHandler = new Helpers.FacebookBackChannelHandler();
                //https://stackoverflow.com/questions/32059384/why-new-fb-api-2-4-returns-null-email-on-mvc-5-with-identity-and-oauth-2
                //https://github.com/aspnet/Security/issues/435
            });
            services.AddAuthentication().AddGoogle(googleOptions =>
            {
                googleOptions.ClientId = Configuration["Settings:Authentication:Google:ClientId"];
                googleOptions.ClientSecret = Configuration["Settings:Authentication:Google:ClientSecret"];
            });
            
            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddMvc();
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "Web API", Description = ".NET Core 2" }); });
        }
