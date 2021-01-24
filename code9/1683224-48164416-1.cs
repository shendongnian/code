    public IWebElement GetButton()
    {
        IWebElement table = driver.FindElement(By.Id("your table's id");
        string buttonText = "Your Button's Text";
        ReadOnlyCollection<IWebElement> buttons = table.FindElements(By.TagName("a")); 
        IWebElement desiredButton = (from button in buttons
                                     where button.Text.Equals(buttonText)
                                     select button).SingleOrDefault();
        return desiredButton;
    }
