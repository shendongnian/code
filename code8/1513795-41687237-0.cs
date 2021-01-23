     public void ClickTableLink(String value2)
      {
      var table =  driver.FindElement(By.Id("myTable"));
      foreach (var tr in table.FindElements(By.TagName("tr")))
      {
       var tds = tr.FindElements(By.TagName("td"));
        for (var i = 0; i < tds.Count; i++)
        {
            if (tds[i].Text.Trim().Contains(value2))
            {
                tds[i - 1].Click();
               break;
            }
            
        }
      }
    }
