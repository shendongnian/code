    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using NUnit.Framework;
    namespace test_TestAutomation.TestClasses
    {
        public class Base
        {
            public static IWebDriver driver;
            [SetUp]
            public void SetUp()
            {
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
            }
            [TearDown]
            public void TearDown()
            {
                driver.Close();
            }
        }
    }
