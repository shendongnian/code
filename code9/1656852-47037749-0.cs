        IReadOnlyCollection<IWebElement> TableRows = Driver.FindElements(By.CssSelector("#nt-item-table tr"));
        for (int i = 0; i < TableRows.Count; i++)
        {
            // do something with TableRows.ElementAt(i);
        }
