    private string GetURLFromProcess(Process process, BrowserType browser)
    {
        if (process == null)
            throw new ArgumentNullException("process");
    
        if (process.MainWindowHandle == IntPtr.Zero)
            return null;
    
        AutomationElement elm = AutomationElement.FromHandle(process.MainWindowHandle);
        if (elm == null)
            return null;
        string nameProperty = "";
    
        if (browser.Equals(BrowserType.GOOGLE_CHROME))
            {
                var elm1 = elm.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, "Google Chrome"));
                if (elm1 == null) { return null; } // not the right chrome.exe
                var elm2 = elm1.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, ""))[1];
                var elm3 = elm2.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, ""))[1];
                var elm4 = elm3.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, ""))[1];
                var elm5 = elm4.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, ""));
                var elmUrlBar = elm5.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit));
                var url = ((ValuePattern)elmUrlBar.GetCurrentPattern(ValuePattern.Pattern)).Current.Value as string;
                return url;
            }
        else if (browser.Equals(BrowserType.FIREFOX))
            {
                 AutomationElement elm2 = elm.FindFirst(TreeScope.Children, new AndCondition(new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.ToolBar),
                        new PropertyCondition(AutomationElement.IsInvokePatternAvailableProperty, false)));
                if (elm2 == null)
                    return null;
                var elm3 = elm2.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.ComboBox));
                if (elm3 == null)
                    return null;
                var elmUrlBar = elm3.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit));
                if (elmUrlBar != null)
                {
                    var url = ((ValuePattern)elmUrlBar.GetCurrentPattern(ValuePattern.Pattern)).Current.Value as string;
                    url;
                }
            }
        else if (browser.Equals(BrowserType.INTERNET_EXPLORER))
            {
                 AutomationElement elm2 = elm.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, "ReBarWindow32"));
                 if (elm2 == null)
                     return null;
                 AutomationElement elmUrlBar = elm2.FindFirst(TreeScope.Subtree, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit));
                 var url = ((ValuePattern)elmUrlBar.GetCurrentPattern(ValuePattern.Pattern)).Current.Value as string;
                 return url;
            }
        else if (browser.Equals(BrowserType.MICROSOFT_EDGE))
            {
                var elm2 = elm.FindFirst(TreeScope.Children, new AndCondition(
                new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Window),
                new PropertyCondition(AutomationElement.NameProperty, "Microsoft Edge")));
    
                var elmUrlBar = elm2.FindFirst(TreeScope.Children,
                    new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit));
    
                var url = ((TextPattern)elmUrlBar.GetCurrentPattern(TextPattern.Pattern)).DocumentRange.GetText(int.MaxValue);
                return url;
            }
    
        return null;
    }
