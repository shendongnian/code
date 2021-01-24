    //
    // This is the handler in the ButtonClicker app, the app that is doing the clicking
    //
    private void go_Click(object sender, EventArgs e)
    {
        // Look for a top-level window/application called "Target Demo"
    	var root = AutomationElement.RootElement;
    	var condition1 = new PropertyCondition(AutomationElement.NameProperty, "Target Demo");
    
    	var treeWalker = new TreeWalker(condition1);
    	AutomationElement element = treeWalker.GetFirstChild(root);
    	
    	if (element == null)
    	{
    		// not found
    		return;
    	}
    
        // great!  window found
    	var window = element;
    
        // now look for a button with the text "Click Me"
    	var buttonElement =window.FindFirst(TreeScope.Children, 
    		new PropertyCondition(AutomationElement.NameProperty, "Click Me"));
    	if (buttonElement == null)
    	{
    		// not found
    		return;
    	}
    
        // great! now click the button
    	var invokePattern = buttonElement.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
    	invokePattern?.Invoke();
    
    }
