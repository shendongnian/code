    try
    {
    	AutomationElement prog = AutomationElement.RootElement.FindFirst(TreeScope.Children,
    		new PropertyCondition(AutomationElement.NameProperty, "Window Title"));
    	var datagrid = prog.FindFirst(TreeScope.Children,
    		new PropertyCondition(AutomationElement.AutomationIdProperty, "Your grid"));
    	var rows = datagrid.FindAll(TreeScope.Children,
    		new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.DataItem));
    	foreach (AutomationElement row in rows)
    	{
    		var findRow = row.FindAll(TreeScope.Children,
    			new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Custom));
    		Console.WriteLine("===============");
    		Console.WriteLine(findRow[1].Current.Name);
    	}
    
    	Console.WriteLine("===============");
    }
    catch (Exception e)
    {
    	Console.WriteLine(string.Format("{0}{1}", e.Message,
    		" At Line:" + e.StackTrace.Substring(e.StackTrace.LastIndexOf(' '))));
    }
    Console.ReadLine();
