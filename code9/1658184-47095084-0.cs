    public IWebDriver WebDriver { get; set; }
    
    IWebElement tableElement = WebDriver.FindElement(By.Id(tableName));
                IWebElement tbodyElement = tableElement.FindElement(By.TagName("tbody"));
                List<IWebElement> rows = new List<IWebElement>(tbodyElement.FindElements(By.TagName("tr")));
                foreach (var row in rows)
                {
                    if (row.GetAttribute("row") != "-1" && (!string.IsNullOrWhiteSpace(row.GetAttribute("row"))))
                    {
                        List<IWebElement> cells = new List<IWebElement>(row.FindElements(By.TagName("td")));
                        if (cells.Count != 0)
                        {
                            if (cells[0].Text == columnName) //Identify the cell, may use other attribute
                            {
                                IWebElement btn = cells[0].FindElement(By.ClassName("btnDefault")) as IWebElement;
                                return btn;
    
                            }
                        }
                    }
                }
