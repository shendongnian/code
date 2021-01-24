    bool CheckIfItExists(string ElementId)
    {
        try
        {
            driver.FindElement(By.Id(ElementId));
            return true;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }
