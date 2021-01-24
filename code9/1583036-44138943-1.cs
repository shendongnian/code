    public void HoverWithActions()
    {
        // using actions
        // now it works :)
        new Actions(PomTest.Driver).MoveToElement(this.Elements.First()).Perform();
    }
    public void HoverWithJS()
    {
        // using Javascript
        // now it works :)
        var mouseOverScript = @"if(document.createEvent){var evObj = document.createEvent('MouseEvents');evObj.initEvent('mouseover', true, false); arguments[0].dispatchEvent(evObj); } else if(document.createEventObject) { arguments[0].fireEvent('onmouseover'); }";
        ((IJavaScriptExecutor)PomTest.Driver).ExecuteScript(mouseOverScript, this.Elements.First());
    }
    [FindsBy(How = How.Id, Using = "nav-questions")]
    public IList<IWebElement> Elements { get; set; }
