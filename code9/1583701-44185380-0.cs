    IWebElement table = driver.FindElement(By.Id("NewBusinessDetailRecords"));
    IList<IWebElement> rows = table.FindElements(By.TagName("tr"));
    foreach (IWebElement row in rows)
    {
        IList<IWebElement> cells = row.FindElements(By.TagName("td"));
        if (cells.Count > 10 && cells[10].Text.Equals("103"))
        {
            cells[0].Click();
        }
    }
