    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Interactions;
    using System;
    
    namespace AutomateQA
    {
        class Program
        {
            static void Main(string[] args)
            {
                var usernameStr = "admin";
                var passwordStr = "admin";
    
                IWebDriver chromeDriver = new ChromeDriver();
                chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                chromeDriver.Url = "http://localhost:81";
    
                var txtUserName = chromeDriver.FindElement(By.Id("txtUserName"));
                txtUserName.SendKeys(usernameStr);
    
                var txtPassword = chromeDriver.FindElement(By.Id("txtPassword"));
                txtPassword.SendKeys(passwordStr);
    
                var btnLogin = chromeDriver.FindElement(By.Id("btnLogin"));
                btnLogin.Click();
    
                var asmtAdminElement = chromeDriver.FindElement(By.LinkText("Asmt Admin"));
                var actions = new Actions(chromeDriver);
                actions.MoveToElement(asmtAdminElement).Perform();
    
                var applicationProcessingSubElement = chromeDriver.FindElement(By.XPath("//a[contains(.,'Application Processing')]"));
                applicationProcessingSubElement.SendKeys(Keys.Enter);
            }
        }
    }
