    public void SubmitTest()
    {
        _driver.Url = "http://mypage.com";
        _driver.FindElement(By.Name("username")).SendKeys("myname");
        _driver.FindElement(By.Name("password")).SendKeys("myeasypassword");
        IWebElement body = _driver.FindElement(By.TagName("body"));
        _driver.FindElement(By.TagName("form")).Submit();
        body = new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.TagName("body")))
        StringAssert.StartsWith("Text in new page", body.Text);
    }
