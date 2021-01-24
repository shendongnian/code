    var config = new Config() 
    {
       SomeTopLevelProp = "ABCDEF",
       LogOnDetails = new LogOnDetails()
       {
           MySqlDatabaseName = "Foo"  ,
           MySQLUser = "MyUser"
           // snip the rest of the props
       },
        OtherDetails = new OtherDetails
        {
            AField = "Bar"
        }
    }
    var json = JsonConvert.SerializeObject(config );
    
    var mySettingDeserialized = JsonConvert.DeserializeObject<Config>(json);
