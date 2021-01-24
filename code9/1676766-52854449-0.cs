      using System;
      using System.Security.Policy;
      using Microsoft.VisualStudio.TestTools.UnitTesting;
      using OpenQA.Selenium;
      using OpenQA.Selenium.Remote;
    
    namespace SeleniumTest
    {
    [TestClass]
    class Program
    {   
     [TestMethod]
       public void Test()
        {
            IWebDriver driver;
            DesiredCapabilities capability = DesiredCapabilities.Chrome();
            capability.SetCapability("browserName", "iPad");
            capability.SetCapability("platform", "MAC");
            capability.SetCapability("device", "undefined");
            capability.SetCapability("browserstack.user", "");
            capability.SetCapability("browserstack.key", "");
    
            driver = new RemoteWebDriver(
              new Uri("http://hub-cloud.browserstack.com/wd/hub/"), capability);
            driver.Navigate().GoToUrl("http://www.google.com");
            Console.WriteLine(driver.Title);
    
            IWebElement query = driver.FindElement(By.Name("q"));
            query.SendKeys("Browserstack");
            query.Submit();
            Console.WriteLine(driver.Title);
    
            driver.Quit();
        }
    }
    }
    **Change the add this code and try to check it by adding in empty Unit test class 
    file**
