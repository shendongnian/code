    public static void Main(string[] args)
    {
        HtmlDocument doc = new HtmlDocument();
        //According to my web debugger the cookie will last until the 10th of December. So need to fix a new cookie until then.
        //I noticed the url used unixtimestamps at the end of the url. So we just add the unixtimestamp at the end for each request.
        long unixTimeStamp = new DateTimeOffset(DateTime.Now).ToUnixTimeMilliseconds() - 100;
        string webAddr = "https://roosters.windesheim.nl/WebUntis/Timetable.do?request.preventCache="+unixTimeStamp.ToString();
        var ffOptions = new FirefoxOptions();
        ffOptions.BrowserExecutableLocation = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
        ffOptions.LogLevel = FirefoxDriverLogLevel.Default;
        ffOptions.Profile = new FirefoxProfile { AcceptUntrustedCertificates = true };
        var service = FirefoxDriverService.CreateDefaultService();
        var driver = new FirefoxDriver(service, ffOptions, TimeSpan.FromSeconds(120));
          
        driver.Navigate().GoToUrl(webAddr);
        driver.FindElement(By.XPath("//input[@id='school']")).SendKeys("Windesheim"+Keys.Enter);
        Thread.Sleep(2000);
        driver.FindElement(By.XPath("//span[@id='dijit_PopupMenuBarItem_0_text' and text() ='Lesrooster']")).Click();
        driver.FindElement(By.XPath("//td[@id='dijit_MenuItem_0_text' and text() ='Klassen']")).Click();
        Thread.Sleep(2000);
        driver.FindElement(By.XPath("//div[@id='widget_Timetable_toolbar_elementSelect']//input[@class='dijitReset dijitInputField dijitArrowButtonInner']")).Click();
        //we get all the options for Klase
        doc.LoadHtml(driver.PageSource);
        HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//div[@id='Timetable_toolbar_elementSelect_popup']/div[@item]");
        List<String> options = new List<String>();
        foreach (HtmlNode n in nodes)
        {
            options.Add(n.InnerText);
        }
        foreach(string s in options)
        {
            driver.FindElement(By.XPath("//input[@id='Timetable_toolbar_elementSelect']")).SendKeys(s);
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//body")).SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            doc.LoadHtml(driver.PageSource);
            //Console.WriteLine(driver.Url); //Now we can see the id of the current Klase
        }
        Console.WriteLine(doc.DocumentNode.InnerHtml);
        Console.ReadKey();
    }
