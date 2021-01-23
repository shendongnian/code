    ClickButton();
    public bool ClickButton()
    {
        IReadOnlyCollection<IWebElement> saveOrg = Driver.FindElements(By.Id("SaveOrg-Button-ID"));
        if (saveOrg.Any())
        {
            saveOrg.ElementAt(0).Click();
            WaitForOrganizationFormToClose();
            return true;
        }
        IReadOnlyCollection<IWebElement> saveNet = Driver.FindElements(By.Id("SaveNet-Button-ID"));
        if (saveNet.Any())
        {
            saveNet.ElementAt(0).Click();
            WaitForNetworkFormToClose();
            return true;
        }
        return false;
    }
