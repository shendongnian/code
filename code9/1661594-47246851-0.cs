    public T ClickTheMenuButtonWorkplace<T>(string ElementID, T ClassToReturn)
    {
        WebDriverWait wait = new WebDriverWait(_webdriver, TimeSpan.FromSeconds(10));
        var MenuButton = wait.Until(x => x.FindElement(By.Id(ElementID)));
        MenuButton.Click();
        return ClassToReturn;
    }
    ...
    var IDDetails = new SargelElyon(_webdriver)
            .ClickTheMenuButtonWorkplace("nav_conts", new Lakochot(_webdriver));
    // ^ is a Lakochot
    IDDetails.foo();
