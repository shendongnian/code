    public class TargetPhoneSetting {
        public string Name { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
    }
    public class AppSettings {
        public List<TargetPhoneSetting> TargetPhones { get; set; } = new List<TargetPhoneSetting>();
        public string SourcePhoneNum { get; set; } = "";
    }
    public static AppSettings GetConfig() {
        string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        var builder = new ConfigurationBuilder()
            .SetBasePath(System.IO.Directory.GetCurrentDirectory())
            .AddYamlFile("appsettings.yml", optional: false)
            ;
        IConfigurationRoot configuration = builder.Build();
        var settings = new AppSettings();
        configuration.Bind(settings);
        return settings;
    }
