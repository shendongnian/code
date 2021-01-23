    public void DisableWheelNavigation(ReportViewer rv)
    {
        bool fromToolbar = false;
        rv.PageNavigation += (obj, ea) =>
        {
            if (fromToolbar) fromToolbar = false;
            else ea.Cancel = true;
        };
        var buttons = new string[] { "firstPage", "previousPage", "nextPage", "lastPage" };
        var toolstrip = rv.Controls.Find("toolStrip1", true).OfType<ToolStrip>().First();
        toolstrip.Items.OfType<ToolStripButton>()
            .Where(button => buttons.Contains(button.Name)).ToList()
            .ForEach(button =>
            {
                var clickEvent = button.GetType().GetEvent("Click");
                var removeMethod = clickEvent.GetRemoveMethod();
                var onPageNavButtonClick = toolstrip.Parent.GetType()
                    .GetMethod("OnPageNavButtonClick",
                    BindingFlags.NonPublic | BindingFlags.Instance);
                var d = Delegate.CreateDelegate(clickEvent.EventHandlerType, 
                    toolstrip.Parent, onPageNavButtonClick);
                removeMethod.Invoke(button, new object[] { d });
                button.Click += (obj, ev) =>
                {
                    var onPageNavigation = toolstrip.Parent.GetType()
                        .GetMethod("OnPageNavigation",
                    BindingFlags.NonPublic | BindingFlags.Instance);
                    Action<int> OnPageNavigation = i =>
                    {
                        fromToolbar = true;
                        onPageNavigation.Invoke(toolstrip.Parent, new object[] { i });
                    };
                    if (button.Name == "firstPage")
                        OnPageNavigation(1);
                    else if (button.Name == "previousPage")
                        OnPageNavigation(rv.CurrentPage - 1);
                    else if (button.Name == "nextPage")
                        OnPageNavigation(rv.CurrentPage + 1);
                    else if (button.Name == "lastPage")
                    {
                        PageCountMode mode;
                        int totalPages = rv.GetTotalPages(out mode);
                        if (mode != PageCountMode.Actual) OnPageNavigation(0x7fffffff);
                        else OnPageNavigation(totalPages);
                    }
                };
            });
    }
