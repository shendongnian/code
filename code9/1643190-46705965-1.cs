    public class ConfigurationManagerConnectionSettings : IConnectionSettings
    {
        public string MyDatabaseConnectionString { get; }
            = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;
    }
    var s = new ConfigurationManagerConnectionSettings();
    var myClass = new MyClass(s);
