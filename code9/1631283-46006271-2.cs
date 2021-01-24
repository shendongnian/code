    public class UserContext
    {
        public UserContext(string config)
        {
            // config used here
        }
    }
    public class ConfigContext
    {
        public string GetConfig()
        {
            return "config";
        }
    }
    public void ConfigureServices(IServiceCollection services)
    {
        // ...
        
        services.AddScoped<ConfigContext>();
        services.AddScoped<UserContext>(sp => 
            new UserContext(sp.GetService<ConfigContext>().GetConfig()));
    }
