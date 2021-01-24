     AutomationElement aeDesktop = AutomationElement.RootElement;
     AutomationElement aeForm = aeDesktop.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, "davinceleecode"));
     AutomationElement aeTabControl = aeForm.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.AutomationIdProperty, "tabControl1"));
     aeTabControl.SetFocus();
     AutomationElement aeTabPage = aeTabControl.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, "tabPage2"));    
     SelectionItemPattern changeTab_aeTabPage = aeTabPage.GetCurrentPattern(SelectionItemPattern.Pattern) as SelectionItemPattern;
    
     changeTab_aeTabPage.Select();
