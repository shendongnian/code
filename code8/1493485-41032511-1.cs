    public static Boolean SwitchWindow(string title)
    {
        var currentWindow_title = WebDriverUtilities3.WebDriver.Driver.Title;
        var currenhandle = WebDriverUtilities3.WebDriver.Driver.CurrentWindowHandle;
        var availableWindows = new List<string>(WebDriverUtilities3.WebDriver.Driver.WindowHandles);
        if (currentWindow_title != title)
        {
            foreach (string w in availableWindows)
            {
                if (currenhandle != w)
                {
                    WebDriverUtilities3.WebDriver.Driver.SwitchTo().Window(w);
                    IJavaScriptExecutor js = (IJavaScriptExecutor)WebDriverUtilities3.WebDriver.Driver;
                    string a = @"window.blur();
                    window.focus();";
                    try
                    {
                        js.ExecuteScript(a);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    js = null;
                    var tit = WebDriverUtilities3.WebDriver.Driver.Title;
                    if (WebDriverUtilities3.WebDriver.Driver.Title == title)
                    {
                        break;
                    }
                }
            }
        }
    }
