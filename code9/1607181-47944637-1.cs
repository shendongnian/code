    System.Windows.Automation.AutomationElement AutomationElement = System.Windows.Automation.AutomationElement.FromHandle(ptr);
    System.Windows.Automation.AutomationElement Elm = AutomationElement.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document));
    System.Windows.Automation.AutomationPattern[] BAutomationPattern = Elm.GetSupportedPatterns();
    System.Windows.Automation.ValuePattern BValuePattern = (System.Windows.Automation.ValuePattern)Elm.GetCurrentPattern(BAutomationPattern[0]);
    CurrentUrlName = BValuePattern.Current.Value.ToString();
