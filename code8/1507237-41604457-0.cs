    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    namespace SeleniumThree
    {
        class Program
        {
            static void Main(string[] args)
            {
                IWebDriver driver = new ChromeDriver();
                driver.Navigate().GoToUrl("www.facebook.com");
                driver.Manage().Window.Maximize();
                IWebElement Username = driver.FindElement(By.Name("FORMLOGINid"));
                Username.SendKeys("UserName");
                Thread.Sleep(1000);
                IWebElement Password = driver.FindElement(By.Name("FORMLOGINpwd"));
                Password.SendKeys("Password");
                Thread.Sleep(1000);
                IWebElement LoginButton = driver.FindElement(By.Name("btSubmit"));
                LoginButton.Click();
                Thread.Sleep(3000);
                try
                {
                    IWebElement MenuArrow = driver.FindElement(By.XPath(@"//*[@id='id_arrow_popup_menu']/img"));
                    MenuArrow.Click();
                    Thread.Sleep(1000);
                    
			    }
			
			     catch (Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e);
                }
			        
           }
       }
    }  
