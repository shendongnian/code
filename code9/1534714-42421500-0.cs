        using OpenQA.Selenium;
        using OpenQA.Selenium.PhantomJS;
        public  void Search(string url)
    {
        var driver = new PhantomJSDriver();
        driver.Navigate().GoToUrl("url");
        var DivValue = driver.FindElementByClassName("ClassName");
    }
