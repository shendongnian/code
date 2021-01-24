    public void WaitSecondsForNewPageToLoad(int maxWaitTimeInSeconds)
    {
        string state = string.Empty;
        bool jQueryActive = true;
        try
        {
            WebDriverWait wait = new WebDriverWait(TestCaseContext.Driver,
                TimeSpan.FromSeconds(maxWaitTimeInSeconds));
            //Checks every 500 ms whether predicate returns true if returns exit otherwise keep trying till it returns true
            wait.Until(d =>
            {
                try
                {
                    state =
                        ((IJavaScriptExecutor) TestCaseContext.Driver).ExecuteScript(
                            @"return document.readyState").ToString();
                    jQueryActive =
                        (bool)((IJavaScriptExecutor) TestCaseContext.Driver).ExecuteScript(
                            @"return jQuery.active == 0");
                    WindowsWhenSteps.WhenIFocusTheCurrentBrowserWindow();
                }
                catch (InvalidOperationException)
                {
                    //Ignore
                }
                return (state.Equals("complete", StringComparison.InvariantCultureIgnoreCase) ||
                        state.Equals("loaded", StringComparison.InvariantCultureIgnoreCase))  &&
                        jQueryActive;
            });
        }
        catch (TimeoutException)
        {
            //sometimes Page remains in Interactive mode and never becomes Complete, then we can still try to access the controls
            if (!state.Equals("interactive", StringComparison.InvariantCultureIgnoreCase))
                Assert.IsTrue(false);
        }
        catch (NullReferenceException)
        {
            //sometimes Page remains in Interactive mode and never becomes Complete, then we can still try to access the controls
            if (!state.Equals("interactive", StringComparison.InvariantCultureIgnoreCase))
                Assert.IsTrue(false);
        }
        catch (WebDriverException)
        {
            if (TestCaseContext.Driver.WindowHandles.Count == 1)
            {
                TestCaseContext.Driver.SwitchTo().Window(TestCaseContext.Driver.WindowHandles[0]);
            }
            state =
                ((IJavaScriptExecutor) TestCaseContext.Driver).ExecuteScript(
                    @"return document.readyState").ToString();
            if (
                !(state.Equals("complete", StringComparison.InvariantCultureIgnoreCase) ||
                  state.Equals("loaded", StringComparison.InvariantCultureIgnoreCase)))
                Assert.IsTrue(false);
        }
    }  
  
