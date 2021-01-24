    public class BasicTestClass
    {
        private IWebDriver driver;
        
        [TestInitialize]
        public void  Init()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.nl");
        }
        [TestCleanup]
        public void Close()
        {
            Driver.Close();
        }
        // TestMethods go here
    } 
