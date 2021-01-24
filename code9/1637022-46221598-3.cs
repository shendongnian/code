    public static IWebElement FindListItem(IWebElement listContainer, string itemText)
        {
           
            List<IWebElement> allOptions = listContainer.FindElements(By.XPath("")).ToList();
            foreach (var webElement in allOptions)
            {
                listContainer.SendKeys(Keys.Down);
               Thread.Sleep(250);
                if (webElement.Text.Contains(itemText))
                    select.selectByVisibleText("Value1");
            }
        }
