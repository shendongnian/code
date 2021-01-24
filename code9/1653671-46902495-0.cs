	public static bool WaitForTextToAppear(this IWebDriver driver, By elementLocator, string textToAppear, int timeoutInSec=10)
	{
		IWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
		wait.Timeout = TimeSpan.FromSeconds(timeoutInSec);
		wait.PollingInterval = TimeSpan.FromMilliseconds(300);
		try
		{
			wait.Until(d => d.IsTextPresentedIn(elementLocator, textToAppear));
			return true;
		}
		catch (Exception ex)
		{
			System.Diagnostics.Debug.WriteLine("Error: " + ex.Message);
			return false;
		}
	}
	private static bool IsTextPresentedIn(this IWebDriver driver, By elementLocator, string textToAppear)
	{
		try
		{
			var elements = driver.FindElements(elementLocator);
			if (elements.Count>0 && elements.First().Text.Equals(textToAppear, StringComparison.OrdinalIgnoreCase))
				return true;
		}
		catch
		{
			return false;
		}
		return false;
	}
    // using the web driver extension.
    bool textAppeared = d.WaitForTextToAppear(By.CssSelector("selector-of-the-text-element"), "HERE IS THE EXPECTED TEXT");
