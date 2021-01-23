    namespace ParallelTests
    {
        public class Base
        {
            public IWebDriver Driver { get; set; }
        }
    
        public class Hooks : Base
        {
            public Hooks()
            {
                Driver = new ChromeDriver();
            }
        }
    
        [TestFixture]
        [Parallelizable]
        public class ChromeTesting : Hooks
        {
            [Test]
            public void ChromegGoogleTest()
            {
                Driver.Navigate().GoToUrl("https://www.google.co.uk");
                Driver.FindElement(By.Id("lst-ib")).SendKeys("Deep Purple");
                Driver.FindElement(By.Id("lst-ib")).SendKeys(Keys.Enter);
                Driver.AssertDisplayed();
            }
        }
    }
