    var trElements = driver.FindElements(By.TagName("tr"));
    List<string> strrr = new List<string>(); 
    foreach (var tr in trElements)
    {
        IWait<IWebElement> wait = new DefaultWait<IWebElement>(tr);
        wait.Timeout = TimeSpan.FromSeconds(10);
        try
        {
            wait.Until(element => element.Text.Trim().Length > 1);
            strrr.Add(element.Text.Trim());
        }
        catch (WebDriverTimeoutException)
        {
            strrr.Add("");
        }
    }
