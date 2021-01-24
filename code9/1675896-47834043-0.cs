	public IWebElement GetScanTextBox(int index)
	{
		return Driver
			.FindElements(By.XPath("//*[@AutomationId='ScanTextBox']"))
			.ElementAt(index);
	}
	
	public void UsageExample()
	{
		var buttonOne = GetScanTextBox(0);
		var buttonTwo = GetScanTextBox(1);	
	}
