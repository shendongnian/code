AppSettings.cs
    public class AppSettings
    {
        public AppSettings()
        {
            // Set default values of our options.
            WarehouseConnectionString = "default_value_if_needed";
        }
    
        public string WarehouseConnectionString { get; set; }
    }
