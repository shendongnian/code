    Process[] procsChrome = Process.GetProcessesByName("chrome");
    if (procsChrome.Length <= 0)
    {
       Console.WriteLine("Chrome is not running");
    }
    else
    {
       foreach (Process proc in procsChrome)
       {
          // the chrome process must have a window 
          if (proc.MainWindowHandle == IntPtr.Zero)
          {
              continue;
          }
          // to find the tabs we first need to locate something reliable - the 'New Tab' button 
          AutomationElement root = AutomationElement.FromHandle(proc.MainWindowHandle);
          Condition condNewTab = new PropertyCondition(AutomationElement.NameProperty, "New Tab");
          AutomationElement elmNewTab = root.FindFirst(TreeScope.Descendants, condNewTab);
          // get the tabstrip by getting the parent of the 'new tab' button 
          TreeWalker treewalker = TreeWalker.ControlViewWalker;
          AutomationElement elmTabStrip = treewalker.GetParent(elmNewTab);
          // loop through all the tabs and get the names which is the page title 
          Condition condTabItem = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.TabItem);
          foreach (AutomationElement tabitem in elmTabStrip.FindAll(TreeScope.Children, condTabItem))
          {
              Console.WriteLine(tabitem.Current.Name);
          }
       }
    }
