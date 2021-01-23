     app.config
     <add key="DatabaseTest" value="myDBConnectionString" />
     <add key="DatabaseDev" value="myDBConnectionString" />
     <add key="Environment" value="test" />
     
     Step:
     using System.Configuration; //make sure you have this included to use ConfigurationManager
        [Given(@"I am connected to my environment database")]
        public void GivenIAmConnectedToMyEnvironmentDatabase()
        {
         
         var myEnv = ConfigurationManager.AppSettings["Environment"];
         switch (myEnv)
         {
           case "test":
             var  _testDatabase = ConfigurationManager.AppSettings["DatabaseTest"];
             //create db connection 
             break;
           case "dev":
              var _devDatabase = ConfigurationManager.AppSettings["DatabaseDev"];
              //create db connection 
              break;
         }
		 }
