    public class DatabaseOptions
    {
        public string DbName { get; set; }
    }
    services.AddOptions();
    services.Configure<DatabaseOptions>(options => options.DbName = "myDbName");
