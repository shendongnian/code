    var notepad = System.Diagnostics.Process.GetProcessesByName("notepad").FirstOrDefault();
    if (notepad != null)
    {
        var root = AutomationElement.FromHandle(notepad.MainWindowHandle);
        var elements = root.FindAll(TreeScope.Subtree, Condition.TrueCondition)
                            .Cast<AutomationElement>();
        //example:
        //elements.Select(x=>x.Current.Name)
        //elements.Select(x => x.Current.ControlType);
        //elements.Select(x => x.Current.NativeWindowHandle);
        //elements.Select(x => x.Current.BoundingRectangle);
    }
