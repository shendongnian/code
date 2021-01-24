    public void SetPropertyTypes(bool residential)
	{
	
		IWebElement _resident = Driver.FindElement(By.CssSelector(propertyTypeResidentialCss));
		IWebElement _commercial = Driver.FindElement(By.CssSelector(propertyTypeCommercialCss));
		
		// Residential Property Type Check logic
		if (residential || _resident.Enabled ) // or _resident.Displayed depending on what you are doing
			_resident.Click();
		else
			_commercial.Click();
	}
