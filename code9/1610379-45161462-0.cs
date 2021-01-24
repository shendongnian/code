    string mainWindowHandle = secondDriver.CurrentWindowHandle;
    for (int k = 4; k < 100; k++) // i do not know how many elements contain
    {
        try
        {
            Thread.Sleep(300);
            IWebElement linkInbox = secondDriver.FindElement(By.XPath(element));
            action.KeyDown(Keys.Shift).Click(linkInbox).Perform();
          secondDriver.SwitchTo().Window(secondDriver.WindowHandles.Last());
        catch (Exception)
        {
            Thread.Sleep(500);
        }
        Thread.Sleep(500);
        secondDriver.Close();
        secondDriver.SwitchTo().Window(mainWindowHandle);
    }
