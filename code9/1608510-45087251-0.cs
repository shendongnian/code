    public static void SelectMultipleGridCell(this IWebElement table, string value)
    {
        IList<IWebElement> tableRow = table.FindElements(By.XPath(".//tr//td[text()='" + value + "']"));
        new WebDriverWait(GeneralProperties.Driver, TimeSpan.FromSeconds(5))
            .Until(ExpectedConditions.ElementExists(By.XPath(".//tr//td[text()='" + value + "']")));
        foreach (IWebElement row in tableRow)
        {
            if (row.IsVisible())
            {
                new Actions(GeneralProperties.Driver).KeyDown(Keys.Control).Click(row).KeyUp(Keys.Control).Build().Perform();
                break;
            }
        }
    }
    
