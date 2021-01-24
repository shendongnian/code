        foreach (AutomationElement a in automationlist)
        {
            if (a.Current.AutomationId == "PersonalCountryCmb")
            {
                ExpandCollapsePattern pattern = (ExpandCollapsePattern)a.GetCurrentPattern(ExpandCollapsePattern.Pattern);
                pattern.Expand();
                
                //Get list
                AutomationElement list = a.FindFirst(TreeScope.Children, new PropertyCondition(
        AutomationElement.LocalizedControlType, "list");
                //Get list item, you will need to replace the condition with something else here
                AutomationElement listItem = a.FindFirst(TreeScope.Children, new PropertyCondition(
        AutomationElement.LocalizedControlType, "list item");
                try
                {
                    SelectionItemPattern pattern1 = (SelectionItemPattern)listItem.GetCurrentPattern(SelectionItemPattern.Pattern);
                    pattern1.Select();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }
        }
