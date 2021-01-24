    public void ShowElement(IWebElement e)
    {
        Actions action = new Actions(Driver);
        action.MoveToElement(e, 0, 0).MoveToElement(e, e.Size.Width, e.Size.Height).Build().Perform();
    }
