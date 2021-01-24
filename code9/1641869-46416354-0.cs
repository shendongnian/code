    for (int i = 0; i <= lastPage; i++)
    {
        var rows = browser
          .FindElements(By.CssSelector("#all_organizations tbody tr"));
        orgs.AddRange(rows.Select(e => BuildOrg(e)));
        
        var link = browser
          .FindElement(By.CssSelector("a"))
        
        link.Click();
        
        new WebDriverWait(browser, TimeSpan.FromSeconds(3))
          .Until(ExpectedConditions.StalenessOf(rows[0]));
    }
