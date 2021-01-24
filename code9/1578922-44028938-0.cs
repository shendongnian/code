    [TestFixture]
    class MockTests
    {
        IWebDriver driver;
        TestLogger logger;
        
        [Setup]
        private void StartTest()
        {
           //This instantiates a new driver and logger each test 
           driver = new ChromeDriver();
           logger = new TestLogger();
        }
        [TestCase(TestName = "mock1")]
        {
            Console.WriteLine("Driver: " + driver.CurrentWindowHandle);
            logger.Out("Hello! I am unique now! 1");
        }
        [TestCase(TestName = "mock2")]
        {
            Console.WriteLine("Driver: " + driver.CurrentWindowHandle);
            logger.Out("Hello! I am unique now! 2");
        }
        [TestCase(TestName = "mock3")]
        {
            Console.WriteLine("Driver: " + driver.CurrentWindowHandle);
            logger.Out("Hello! I am unique now! 3");
        }
        [TearDown]
        private void EndTest()
        {
            driver.Quit();
            logger.PrintReport(TestContext.CurrentContext.Test.Name, TestContext.CurrentContext.Result.Outcome.ToString());
        }
    }
