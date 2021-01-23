    public void SubscribeToInvoke()
            {
                Automation.AddAutomationEventHandler(AutomationElement.MenuOpenedEvent,
                        AutomationElement.RootElement,
                        TreeScope.Descendants, UIAEventHandler);
    
    Automation.AddAutomationEventHandler(AutomationElement.MenuClosedEvent,
                        AutomationElement.RootElement,
                        TreeScope.Descendants, UIAEventHandler);
            }
