    // Get all the elements in the top tab section
    //The first page of the frist tab is already accessed
    //Get all the page links that are in the left navigation bar, click on the page and then move onto the next one
    //Once the last page is accessed, move to the next tab and repeat.
    foreach (IWebElement element in driver.FindElements(By.XPath("//*[@class='TabList ClearFix']//a[@tabindex=-1]")))
    {
        Console.WriteLine(element.Text.ToString());
        foreach (IWebElement lElement in driver.FindElements(By.XPath("//*[@id='LeftMenu']//a[@tabindex=-1]")))
        {
            Console.WriteLine(lElement.Text.ToString());
        }
        element.Click();
    }
