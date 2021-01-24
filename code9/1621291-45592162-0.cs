    IDictionary<IWebElement, IList<IWebElement>> dict = new Dictionary<IWebElement, IList<IWebElement>>();
    
    int index = 0;
    foreach (var header in headersRows.SelectMany(r => r.FindElements(By.XPath("th"))))
    {
        dict.Add(header, resultsRows.Select(r => r.FindElements(By.TagName("td"))[index]).ToList());
        index++;
    }
