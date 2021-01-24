    string mainWindowHandle = secondDriver.CurrentWindowHandle;
    for (int k = 4; k < 100; k++) // i do not know how many elements contain
    {
      try
      {
        Thread.Sleep(300);
        IWebElement linkInbox = secondDriver.FindElement(By.XPath(element));
        var script = "arguments[0].setAttribute('target','_blank');"
        ((IJavaScriptExecutor)secondDriver).ExecuteScript(script, linkInbox);
        Thread.Sleep(1000);
        linkInbox.Click();
        Thread.Sleep(1000);
        secondDriver.SwitchTo().Window(secondDriver.WindowHandles.Last());
        // do the thing here
    
        Thread.Sleep(500);
        secondDriver.Close();
        secondDriver.SwitchTo().Window(mainWindowHandle);
      catch (Exception)
      {
        Thread.Sleep(500);
      }
      if(secondDriver.WindowHandles.Count()>1)
      {
        secondDriver.SwitchTo().Window(secondDriver.WindowHandles.Last()).Close();
        secondDriver.SwitchTo().Window(mainWindowHandle);
      }
    }
