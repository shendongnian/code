      public void ClickTableLink(String issueNumber)
       {
          var table =  driver.FindElements(By.Id("complaintsTable"));
        foreach (var tr in table.FindElements(By.TagName("tr")))
        {
            for (var i = 0; i < tds.Count; i++)
            {
                if (tds[i].Text.Trim().Contains(issueNumber))
                {
                    tds[i - 3].Click();
                   return true;
                }
            }
          }
        }
