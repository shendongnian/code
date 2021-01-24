    public IWebElement WaitForElement(By element)
        {
                return new WebDriverWait(this.browser,
                    TimeSpan.FromSeconds(10)).
                    Until(ExpectedConditions.
                    ElementIsVisible(element));
        }
