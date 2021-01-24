    var config = new Config() 
    {
       SomeTopLevelProp = "ABCDEF",
       LogOnDetails = new LogOnDetails()
       {
           MySqlDatabaseName = "Foo"  ,
           MySQLUser = "MyUser"
           // snip the rest of the props
       },
        Settings = new Settings
        {
            Locale = "en-GB"
        }
    }
    var json = JsonConvert.SerializeObject(config );
    
    var mySettingDeserialized = JsonConvert.DeserializeObject<Config>(json);
