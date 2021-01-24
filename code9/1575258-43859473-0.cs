     public void ClickTableLink(string value)
     {
     var table =  driver.FindElement(By.Id("assetGroup-table"));
     foreach (var tr in table.FindElements(By.TagName("tr")))
     {
     var tds = tr.FindElements(By.TagName("td"));
    for (var i = 0; i < tds.Count; i++)
    {
        if (tds[i].Text.Trim().Contains(value))
        {
            tds[i + 4].Click();
            break;
        }
        
       }
      }
    }
