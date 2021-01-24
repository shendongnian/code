    IWebElement ntTable = driver.FindElement(By.Id("nt-item-table"));
    IReadOnlyCollection<IWebElement> tableRows = ntTable.FindElements(By.TagName("tr")).ToList();
    for (int i = 0; i <= tableRows.Count; i++)
    {
        tdCollection = tableRows[i].FindElements(By.TagName("td"));
        for (int c = 0; c <= tdCollection.Count; c++)
        {
            string column = tdCollection[c].Text;
        }
    }
