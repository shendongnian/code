    public class RunTest
    {
        private IWebDriver driver = null;
        [SetUp]
        public void Login()
        {
        }
        [Test]
        public void AddBatchTest()
        {
            var AddBatch = new Batch(driver);
            AddBatch.AddNewBatch("Test1");
        }
        [Test]
        public void Test1()
        {
            var NewCli = new AddNewClient(driver);
            NewCli.Addanewclient("Test1");
        }
        [TearDown]
        public void TearDown()
        {
            if (Driver != null)
            {
                Driver.Quit();
            }
        }
    }
    
