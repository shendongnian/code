    private static void ChooseZipCode(IWebDriver wd)
    {
    	if (!wd.FindElement(By.XPath("//td[@id='divShipStateCombo']/select//option[3]")).Selected)
    	{
    		wd.FindElement(By.XPath("//td[@id='divShipStateCombo']/select//option[3]")).Click();
    	}
    }
    // where is "[3]" the position your element(ID) in drop down menu
    // or
    private static void SelectElement(IWebDriver wd, string CardType)
    {
    	SelectElement cardSelect = newSelectElement(wd.FindElement(By.Name("CardType")));
    	cardSelect.SelectByText("Visa Card");
    }
