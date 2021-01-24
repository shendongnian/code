        public static IConfiguration _configuration { get; set; }
        
        public TestMasterClass(){
            _configuration = AnotherClassFile.getConfig();
        }
        [TestMethod]
        public void TestConfigElasticSearch()
        {
           
            var elasticSearch = _configuration["ElasticSearchConfig:Link01"];
            Assert.IsNotNull(elasticSearch);
            
        }
