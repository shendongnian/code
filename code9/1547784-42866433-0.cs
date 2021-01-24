    using System.Xml.Linq;
    using System.Threading;
    using System.Linq;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    namespace MCESA_SmokeTest
    {
       public class SmokeTest
       {
          IWebDriver chromeDriver = new ChromeDriver(@"C:\Users\xxxxx\Selenium Stuff\Drivers");
          [Test]
          public void NavigateToHomePageInProduction()
          {
             chromeDriver.Navigate().GoToUrl(@"https://xxx.xxx.xxx/XXXX");
             chromeDriver.Manage().Window.Maximize();
             XDocument rootElement = XDocument.Load(@"C:\Test Data.xml");
             var result = rootElement.Descendants("Login").Select(lg =>
                  new
                  {
                     user = lg.Element("Username").Value,
                     password = lg.Element("Password").Value
                  });
             foreach (var temp in result)
             {
                chromeDriver.FindElement(By.Id(@"userNameInput")).SendKeys(temp.user);
                chromeDriver.FindElement(By.Id(@"passwordInput")).SendKeys(temp.password);
                chromeDriver.FindElement(By.Id(@"submitButton")).Click();
                Thread.Sleep(10);
                bool isVisible = chromeDriver.FindElement(By.Id(@"logoImage")).Displayed;
                isVisible = chromeDriver.FindElement(By.ClassName(@"Header_mcesa")).Displayed;
                chromeDriver.FindElement(By.Id(@"logout")).Click();
             }
             chromeDriver.Quit();
          }  
       }
    }
