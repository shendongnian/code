    IReadOnlyCollection<IWebElement> search = GetVisibleElements(By.Name("search"));
    if (search.Any())
    {
        search.ElementAt(0).SendKeys(query + Keys.Enter);
        if (GetVisibleElements(By.XPath("//*[@id='not found']/h2")).Any())
        {
            // search not found
            Console.WriteLine("search not found");
            Driver.Manage().Cookies.DeleteAllCookies();
            Driver.Navigate().GoToUrl("https://example.com");
        }
        else
        {
            // search found
            // do stuff here
        }
    }
