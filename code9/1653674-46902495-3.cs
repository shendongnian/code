	public bool WaitForTextToAppear(IWebDriver driver, By elementLocator, string textToAppear, int timeoutInSec=10)
	{
		IWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
		wait.Timeout = TimeSpan.FromSeconds(timeoutInSec);
		wait.PollingInterval = TimeSpan.FromMilliseconds(300);
		try
		{
			wait.Until(d => IsTextPresentedIn(d, elementLocator, textToAppear));
			return true;
		}
		catch (Exception ex)
		{
			System.Diagnostics.Debug.WriteLine("Error: " + ex.Message);
			return false;
		}
	}
	private bool IsTextPresentedIn(IWebDriver driver, By elementLocator, string textToAppear)
	{
		try
		{
			var elements = driver.FindElements(elementLocator);
			if (elements.Count>0 && elements[0].Text.Equals(textToAppear, StringComparison.OrdinalIgnoreCase))
				return true;
		}
		catch
		{
			return false;
		}
		return false;
	}
    // using the web driver extension.
    bool textAppeared = WaitForTextToAppear(driver, By.CssSelector("selector-of-the-text-element"), "HERE IS THE EXPECTED TEXT");
