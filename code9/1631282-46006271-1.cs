    public class UserContext
    {
        public UserContext(string config)
        {
        }
    }
    public class ConfigContext
    {
        public string GetConfig()
        {
            return "config";
        }
    }
    services.AddScoped<ConfigContext>();
    services.AddScoped<UserContext>(sp => new UserContext(sp.GetService<ConfigContext>().GetConfig()));
