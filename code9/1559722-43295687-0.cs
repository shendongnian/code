    class SamplePage
    {
        public IWebDriver Driver;
        private By waitForLocator = By.Id("sampleId");
        // please put the variable declarations in alphabetical order
        private By sampleElementLocator = By.Id("sampleId");
        public SamplePage(IWebDriver webDriver)
        {
            this.Driver = webDriver;
            // wait for page to finish loading
            new WebDriverWait(Driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(waitForLocator));
            // see if we're on the right page
            if (!Driver.Url.Contains("samplePage.jsp"))
            {
                throw new InvalidOperationException("This is not the Sample page. Current URL: " + Driver.Url);
            }
        }
        public void ClickSampleElement()
        {
            Driver.FindElement(sampleElementLocator).Click();
        }
    }
