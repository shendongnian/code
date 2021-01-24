    public void ConfigureServices(IServiceCollection services)
            {
                services.AddIdentity<MyApplicationUser, MyRole>(config =>
                {
                    config.User.RequireUniqueEmail = true;
                    config.Password.RequiredLength = 8;
                }).AddEntityFrameworkStores<MyApplicationContext>();
                ...
