    [When(@"I click the Login button")]
    public void WhenIClickTheLoginButton()
    {
        _driver.Click(ElementType.Id, VariableList.LoginButtonId); //Clicks login button first
        switch (_driver.Url)
        {
            case BaseUrls.HomepageUk:
                break;
            case BaseUrls.LogonPageUk:
                break;
            case BaseUrls.PromoPageUk:
                _driver.WaitForElementPresent(ElementType.Id, VariableList.PromoBanner);
                _driver.AssertElementDisplayed(ElementType.Id, VariableList.PromoBanner);
                _driver.AssertElementDisplayed(ElementType.XPath, VariableList.ContinueToHomepageButton);
                _driver.Click(ElementType.XPath, VariableList.ContinueToHomepageButton);
                break;
            default:
                // some assert that the URL is not one of the acceptable three
                break;
        }
    }
