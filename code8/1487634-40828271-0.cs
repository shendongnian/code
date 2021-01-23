        public void ClickTableLink(String issueNumber)
        {
            var table = driver.FindElements(By.TagName("tr"));
            foreach (var tr in table)
            {
                var tds = tr.FindElements(By.TagName("td"));
                for (var i = 0; i < tds.Count; i++)
                {
                    if (tds[i].Text.Trim().Contains(issueNumber))
                    {
                        tds[i - 3].Click();
                        break;
                    }
                }
            }
        }
        
