    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    IWebElement option = wait.Until<IWebElement>((d) =>
    {
        try
        {
            IWebElement element = d.FindElement(By.XPath("//*[@id='ctl00_cphmain_txtCity']/div"));
            if (element.Displayed)
            {
                return element;
            }
        }
        catch (NoSuchElementException ) { }
        catch (StaleElementReferenceException) { }
        return null;
    });
    option.Click();
