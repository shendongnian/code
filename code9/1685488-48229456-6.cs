    try
    {
        element = driver.FindElement(By...);
        element.Click();  // safe because there was no exception
    }
    catch (Exception)
    {
        // empty catch is bad, log this at least
    }
