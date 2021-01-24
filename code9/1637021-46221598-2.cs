     public static IWebElement FindListItem(IWebElement listContainer, string itemText)
        {
            List<IWebElement> allOptions = listContainer.FindElements(By.XPath(""));
            foreach (var webElement in allOptions)
            {
                listContainer.sendKeys(Keys.DOWN);
                sleep(250);
                if (webElement.Text.Contains(text))
                select.selectByVisibleText("Value1");
            }
        }
     
