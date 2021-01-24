	public void clickLang_assertContent(String lang, String text_to_assert )
	{
	    Browser.Driver.FindElement(By.Id("dropdownMenuLang")).Click();
	    Browser.Driver.FindElement(By.XPath("//span[.='" + lang + "']")).Click();
	    IWebElement body = new WebDriverWait(driver, new TimeSpan(0,0,10)).Until(ExpectedConditions.ElementIsVisible(By.TagName("body")));
	    Assert.IsTrue(body.Text.Contains("Temperatura del frigorífico durante"));
	}
