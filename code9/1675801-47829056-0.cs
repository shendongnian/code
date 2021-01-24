    try
    {
    driver.FindElement(By.Id("id")).Enabled;
    driver.FindElement(By.Id("id")).Click();
    }
    catch
    {
    Console.WriteLine("Logout button was not visible!");
    }
