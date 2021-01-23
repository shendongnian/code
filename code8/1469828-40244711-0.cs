    public static bool IsElementPresent(By by)
    {
        try
        {
           bool b = Drivers._driverInstance.FindElement(by).Displayed;
           return b;
        }
        catch
        {
           return false;
        }
    }
