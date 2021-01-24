    private void StartTesting()
        {
            foreach (var testCase in CurrentTestCases)
            {
                Browser.Driver.FindElement(By.Id(testCase.Id)).Click();
                Browser.Driver.FindElement(By.XPath(testCase.XPath)).Click();
                WebDriverWait wait = new WebDriverWait(Browser.Driver, new TimeSpan(0,0,10));
                IWebElement body3 = Browser.Driver.FindElement(By.TagName(testCase.ElementTag));
                Assert.IsTrue(body3.Text.Contains(testCase.TextToMatch));
            }
        }
