    public static bool IsPresent(string id)
    {
        try
        {
            Driver.Instance.FindElement(By.Id(id);
            return true;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }
