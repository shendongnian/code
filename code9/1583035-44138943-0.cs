    public void HoverWithActions()
    {
        // using actions
        // throws System.Reflection.TargetException;
        new Actions(PomTest.Driver).MoveToElement(this.Elements.First()).Perform();
    }
    public void HoverWithJS()
    {
        // using Javascript
        // throws System.ArgumentException
        var mouseOverScript = @"if(document.createEvent){var evObj = document.createEvent('MouseEvents');evObj.initEvent('mouseover', true, false); arguments[0].dispatchEvent(evObj); } else if(document.createEventObject) { arguments[0].fireEvent('onmouseover'); }";
        ((IJavaScriptExecutor)PomTest.Driver).ExecuteScript(mouseOverScript, this.Elements.First());
    }
    [FindsBy(How = How.Id, Using = "nav-questions")]
    public IList<IWebElement> Elements { get; set; }
