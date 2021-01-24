    IReadOnlyCollection<IWebElement> links = PropertiesCollections.driver.FindElements(By.LinkText("Delete")); // gets a collection of elements with Delete as a link
    while (links.Any()) // if the collection is not empty, this evaluates to `true`
    {
        links.ElementAt(0).Click(); // click the first (and probably only?) element
        // do stuff
        PropertiesCollections.driver.FindElement(By.Id("remove_shares"));
        PropertiesCollections.driver.FindElement(By.XPath("(//button[@type='button'])[2]")).Click();
        // get the Delete links again so we can return to the start of the `while` and see if it's still not empty
        links = PropertiesCollections.driver.FindElements(By.LinkText("Delete"));
    }
