    public class MyProModel
    {
        public Dictionary<string, string> MyProData { get; set; }
    }
    var appSettings = ConfigurationManager.AppSettings;
    var myProModel = new MyProModel
    {
        MyProData = appSettings.AllKeys.ToDictionary(k => k, k => appSettings[k])
    };
