    public void SetValue(string value)
    {
        IWebElement dropdown = Driver.FindElement(By.Id("prdtype_listbox"));
        dropdown.Click();
        dropdown.FindElement(By.XPath($".//li[.='{value}']")).Click();
    }
