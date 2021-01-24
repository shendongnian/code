	public static bool WaitForElementToBeInvisible(this IWebElement element, int timeoutSecond = 10)
	{
		IWait<IWebElement> wait = new DefaultWait<IWebElement>(element);
		wait.Timeout = TimeSpan.FromSeconds(timeoutSecond);
		wait.PollingInterval = TimeSpan.FromMilliseconds(300);
		try
		{
			wait.Until(!element.Displayed);
		}
		catch (WebDriverTimeoutException)
		{
			return false;
		}
		return true;
	}
    
    IWebElement div = driver.FindElement(By.Id("id"));
    var result = div.WaitForElementToBeInvisible(5);
