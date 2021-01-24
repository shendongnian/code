    var row = driver.FindElements(By.CssSelector("table#NewBusinessDetailRecords tr#0")).ToList();
    var cells = row.FindElements(By.TagName("td")).ToList();
    if (cells[10].Text.Equals("103"))
    {
    	cells[10].Click();
    }
