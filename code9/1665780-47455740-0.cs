    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;
    using BrowserStack;
    using System.Collections.Generic;
    using OpenQA.Selenium.Chrome;
    using System.Threading;
    namespace BrowserStackLocalSample
    {
        class Program
        {
        static void Main(string[] args)
        {
            IWebDriver driver;
            var browserStackLocal = new Local();
            List<KeyValuePair<string, string>> bsLocalArgs = new List<KeyValuePair<string, string>>() {
                new KeyValuePair<string, string>("key", "<access_key>"),
                new KeyValuePair<string, string>("logfile", "path_To_log/log.txt"),
                //new KeyValuePair<string, string>("binarypath", "/Tools/local/BrowserStackLocal"),
                new KeyValuePair<string, string>("force", "true"),
            };
            browserStackLocal.start(bsLocalArgs);
            Thread.Sleep(15000);
		
            DesiredCapabilities capability = new DesiredCapabilities();
            capability.SetCapability("browser", "Chrome");
            capability.SetCapability("browser_version", "62.0");
            capability.SetCapability("os", "Windows");
            capability.SetCapability("os_version", "7");
            capability.SetCapability("resolution", "1024x768");
            capability.SetCapability("browserstack.local", "true");
            capability.SetCapability("browserstack.user", "<username>");
            capability.SetCapability("browserstack.key", "<access_key>");
            driver = new RemoteWebDriver(
              new Uri("http://hub.browserstack.com/wd/hub/"), capability
            );
            driver.Navigate().GoToUrl("http://localhost:45691/check");
            Console.WriteLine(driver.Title);
            driver.Quit();
            browserStackLocal.stop();
        }
    }
    }
