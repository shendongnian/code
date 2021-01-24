     public static void JsClick (IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)ContextDriver.GetDriver();
            js.ExecuteScript("arguments[0].click();", element);
        }
