    public static IEnumerable TestData
    {
        get
        {
            string[] browsers = BrowsersList.theBrowserList.Split(',')
            string[] urls = UrlsList.theUrlList.Split(',')
                
            foreach (string browser in browsers)
            {
                foreach (string url in urls)
                {
                    yield return new TestCaseData(browser, url);
                }
            }
        }
    }
