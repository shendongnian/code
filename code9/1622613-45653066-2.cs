    public interface IConfigManager
    {
        IAppConfig _config { get; set; }
    }
    public class ConfigManager : IConfigManager
        {
            public IAppConfig _config { get; set; }
            public ConfigManager(IAppConfig config)
            {
                this._config = config;
            }
    
        }
    }
