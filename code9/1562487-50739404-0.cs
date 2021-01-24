    private static bool IsElementPresent(WindowsDriver<AppiumWebElement> driver, Action findAction)
    {
        driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.Zero);
        try
        {
            findAction();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
        finally
        {
            driver.Manage().Timeouts().ImplicitlyWait(GuiTestRunner.Timeout);
        }
    }
