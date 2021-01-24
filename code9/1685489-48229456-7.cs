    IWebElement element = null;
    try
    {
        element = driver.FindElement(By...);
    }
    catch (Exception)
    {
        // empty catch is bad, log this at least
    }
    element.Click(); // still a bug if there was an exception this will cause a NullReferenceException
