    var anyDuplicates = SeleniumContext
        .Driver
        .FindElements(By.XPath(ComparisonTableElements.ProductTitle))
        .GroupBy(p => p.Text, p => p)
        .Any(g => g.Count() > 1);
    Assert.That(anyDuplicates, Is.False);
