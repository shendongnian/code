    var productTitles = SeleniumContext.Driver.FindElements(By.XPath(ComparisonTableElements.ProductTitle));
    foreach(var x in productTitles) {
      if (productTitles.Where(y => x.Text == y.Text).Count() > 1) {
        Assert.Fail("Found duplicate product in the table");
      }
    }
