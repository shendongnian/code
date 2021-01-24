    public IWebElement GetElements(params By[] searchBy)
    {
        var list = new List<IWebElement>();
        foreach (var by in searchBy)
        {
            list.AddRange(driver.FindElements(by));              
        }
        return list.Count == 1 ? list[0] : null;
    }
