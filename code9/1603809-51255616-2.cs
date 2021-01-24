    public static IConfiguration getConfig(){ 
       var config = new ConfigurationBuilder() 
         .SetBasePath("/Users/Project/")
         .AddJsonFile("appsettings.json")  
         .Build(); 
       return config; 
    }
------------------------------------------------------------------------
        [TestClass]
        public class TestMasterClass
        {
            public static IConfiguration _configuration { get; set; }
            
            public TestMasterClass()
            {
                _configuration = AnotherClassFile.getConfig();
            }
    
            [TestMethod]
            public void TestConfigElasticSearch()
            {
               
                var elasticSearch = _configuration["ElasticSearchConfig:Link01"];
                Assert.IsNotNull(elasticSearch);
            }
        }
