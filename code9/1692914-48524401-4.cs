    var productTitles = SeleniumContext
        .Driver
        .FindElements(By.XPath(ComparisonTableElements.ProductTitle))
        .Select(p => p.Text)
        .ToArray();
    var distinctProductTitles = productTitles.Distinct().ToArray();
    Assert.AreEqual(productTitles.Length, distinctProductTitles.Length);
