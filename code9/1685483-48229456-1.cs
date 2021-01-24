    IWebElement element = null;
    try
    {
        element = driver.FindElement(By...);
    }
    catch (Exception)
    {
        // logging or so ...
    }
    element.Click(); // still a bug if there was an exception this will cause a NullReferenceException
