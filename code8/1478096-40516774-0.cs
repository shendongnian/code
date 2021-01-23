    static void Click(IWebElement element, int timeout = 5) {
        var wait = new DefaultWait<IWebElement>(element);
        wait.IgnoreExceptionTypes(typeof(WebDriverException));
        wait.PollingInterval = TimeSpan.FromMilliseconds(10);
        wait.Timeout = TimeSpan.FromSeconds(timeout);
        wait.Until<bool>(drv => {
            element.Click();
            return true;
        });
    }
