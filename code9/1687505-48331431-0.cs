     ValuePattern chromeValuePattern;
      AutomationPropertyChangedEventHandler propChangeHandler = null;
    
      chromeValuePattern = elementx.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
                    
                    propChangeHandler += new AutomationPropertyChangedEventHandler(OnPropertyChange);
                    Automation.AddAutomationPropertyChangedEventHandler(elementx,
                        System.Windows.Automation.TreeScope.Subtree, propChangeHandler,
                        AutomationProperty.LookupById(UIA_PropertyIds.UIA_ValueValuePropertyId));
    
    
    
       private void OnPropertyChange(object src, AutomationPropertyChangedEventArgs e)
            { 
                AutomationElement sourceElement = src as AutomationElement;
               
                if (e.Property == AutomationProperty.LookupById(UIA_PropertyIds.UIA_ValueValuePropertyId))
                {
                   
                    Debug.WriteLine(e.NewValue);
                    
                }
                else
                {
                   
                }
            }
