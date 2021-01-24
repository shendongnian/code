    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    try
    {
        wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("id"))).Click();
    }
    catch (WebDriverTimeoutException)
    {
        Console.WriteLine("Logout button was not visible!");
    }
