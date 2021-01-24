    while (true)
    {
        try
        {
            var clickButton = Driver.Instance.FindElement(By.LinkText("Leather Utility Vest"));
            clickButton.Click();
            break;
        }
        catch(Exception)
        {
            Driver.Instance.Navigate().Refresh();
        }
    }
