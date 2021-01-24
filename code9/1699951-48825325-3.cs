    public void clickLang_assertContent(String lang, String text_to_assert)
    {
        Browser.Driver.FindElement(By.Id("dropdownMenuLang")).Click();
        Browser.Driver.FindElement(By.XPath("//span[.='" + lang + "']")).Click();
        WebDriverWait wait = new WebDriverWait(Browser.Driver, new TimeSpan(0,0,10));
        IWebElement body = wait.Until(ExpectedConditions.ElementIsVisible(By.TagName("body")));
        Assert.IsTrue(body.Text.Contains(text_to_assert));
    }
