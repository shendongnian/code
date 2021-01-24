    int n;
    bool searchWithNumber = int.TryParse(p0, out n);
    
    var transName = driver.FindElement(By.Id("XXX"));
    if (transName.Displayed && !searchWithNumber)
    {
      Assert.That(tarnsName.Text.Contains(p0));
    }
    else if (searchWithNumber)
    {
    var accName = driver.FindElement(By.Id("YYY"));
    if (accName.Displayed)
    {
     Assert.That(accName.Text.Contains(p0));
    }
    else
    {
      Assert.That(true.Equals(false));
       }
     }
