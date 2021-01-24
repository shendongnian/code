    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;
    
    namespace SampleTests {
    
        class OpenNewTab {
    
            static void Main(string[] args) {
    
                IWebDriver driver = new FirefoxDriver();
                driver.Navigate().GoToUrl("http://stackoverflow.com/");
    
                IWebElement body = driver.FindElement(By.TagName("body"));
                body.SendKeys(Keys.Control + 't');
                driver.Navigate().GoToUrl("http://mysecondsite.com/")
                driver.Quit();
            }
        }
    }
