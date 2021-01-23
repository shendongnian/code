    ClickButton(SaveNetworkBtn);
    public bool ClickButton(IWebElement button)
    {
    bool buttonClicked = false;
        if (Driver.FindElements(By.Id("SaveOrg-Button-ID")).Count > 1)
        {
                if (button == SaveOrganizationBtn)
                {
                    SaveOrganizationBtn.Click();
                    WaitForOrganizationFormToClose();
                    buttonClicked = true;
                    return buttonClicked;
                }
        }
        if (Driver.FindElements(By.Id("SaveNet-Button-ID")).Count > 1)
        {
                if (button == SaveNetworkBtn)
                {
                    SaveNetworkBtn.Click();
                    WaitForNetworkFormToClose();
                    buttonClicked = true;
                    return buttonClicked;
                }
        }
    return buttonClicked;
    }
