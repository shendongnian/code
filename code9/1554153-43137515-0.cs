    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support;
    using OpenQA.Selenium.Chrome;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                IWebDriver driver = new ChromeDriver();
                driver.Navigate().GoToUrl("http://google.com");
            }
        }
    }
