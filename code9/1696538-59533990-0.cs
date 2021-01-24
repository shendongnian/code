    [TestClass]
    public class IntegrationTests
    {
        
        public IntegrationTests()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appconfig.json").Build();
            
            _numberOfPumps = Convert.ToInt32(config["NumberOfPumps"]);
            _numberOfMessages = Convert.ToInt32(config["NumberOfMessages"]);
            _databaseUrl = config["DatabaseUrlAddress"];
        }
    } 
