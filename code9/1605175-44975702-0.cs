    IWebDriver driver;
    try
    {
        // locate image
        IWebElement image = driver.FindElement(By.XPath("//img[@alt='Intel']"));
        // get image attributes
        string title = image.GetAttribute("title");
        string alt = image.GetAttribute("alt");
        string src = image.GetAttribute("src");
        // validate title, alt, and src
        // EX: Assert.AreEqual("Intel", title);
    }
    catch (NoSuchElementException)
    {
        // image does not exist, handle accordingly
    }
