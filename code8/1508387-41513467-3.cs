	public static void ClickOn(this RemoteWebDriver driver, IWebElement expectedElement)
	{
		try
		{
			expectedElement.Click();
		}
		catch (InvalidOperationException)
		{
			if (expectedElement.Location.Y > driver.GetWindowHeight())
			{
				driver.ScrollTo(expectedElement.Location.Y + expectedElement.Size.Height);
				Thread.Sleep(500);
			}
			driver.WaitUntil(SearchElementDefaultTimeout, (d) => driver.IsElementClickable(expectedElement));
			expectedElement.Click();
		}
	}
	private static bool IsElementClickable(this RemoteWebDriver driver, IWebElement element)
	{
		return (bool)driver.ExecuteScript(@"
				window.__selenium__isElementClickable = window.__selenium__isElementClickable || function(element)
				{
					var rec = element.getBoundingClientRect();
					var elementAtPosition = document.elementFromPoint(rec.left, rec.top);
					return element == elementAtPosition;
				};
				return window.__selenium__isElementClickable(arguments[0]);
		", element);
	}
