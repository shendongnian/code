    IWebElement table = driver.FindElement(By.XPath("//*[@id='NewBusinessDetailRecords']"));
    var rows = table.FindElements(By.TagName("tr")).ToList();
    var cells = row[0].FindElements(By.TagName("td")).ToList();
    if (cells[10].Text.Equals("103"))
    {
    	cells[10].Click();
    }
