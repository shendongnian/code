    var titles = new HashSet<string>();
    foreach (var title in SeleniumContext
        .Driver
        .FindElements(By.XPath(ComparisonTableElements.ProductTitle))
        .Select(p => p.Text))
    {
        if (!titles.Add(title))
        {
            Assert.Fail("Found duplicate product in the table");
        }
    }
