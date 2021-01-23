    AutomationElement dataGrid = grdControl as AutomationElement;
    AutomationElement outerRow = dataGrid.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, "Record"));
    AutomationElement innerRow = outerRow.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, "Record"));
    AutomationElement custom = innerRow.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "custom"));
    AutomationElement text = custom.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "text"));
    return text.Name;
