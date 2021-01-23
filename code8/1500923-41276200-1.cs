    public void DisableWheelNavigation(ReportViewer r) {
        bool fromToolbar = false;
        r.PageNavigation += (obj, ea) => {
            if (fromToolbar) fromToolbar = false;
            else ea.Cancel = true;
        };
        var buttons = new string[] { "firstPage", "previousPage", "nextPage", "lastPage" };
        var toolstrip = r.Controls.Find("toolStrip1", true).OfType<ToolStrip>().First();
        toolstrip.Items.OfType<ToolStripButton>()
            .Where(button => buttons.Contains(button.Name)).ToList().ForEach(item => {
                var clickEvent = item.GetType().GetEvent("Click");
                var removeMethod = clickEvent.GetRemoveMethod();
                var d = Delegate.CreateDelegate(clickEvent.EventHandlerType,
                    toolstrip.Parent, "OnPageNavButtonClick");
                removeMethod.Invoke(item, new object[] { d });
                item.Click += (obj, ev) => {
                    var onPageNavigation = toolstrip.Parent.GetType()
                        .GetMethod("OnPageNavigation",
                    BindingFlags.NonPublic | BindingFlags.Instance);
                    Action<int> OnPageNavigation = i => {
                        fromToolbar = true;
                        onPageNavigation.Invoke(toolstrip.Parent, new object[] { i });
                    };
                    if (item.Name == "firstPage") OnPageNavigation(1);
                    else if (item.Name == "previousPage") OnPageNavigation(r.CurrentPage - 1);
                    else if (item.Name == "nextPage") OnPageNavigation(r.CurrentPage + 1);
                    else if (item.Name == "lastPage") {
                        PageCountMode mode;
                        int totalPages = r.GetTotalPages(out mode);
                        if (mode != PageCountMode.Actual) OnPageNavigation(0x7fffffff);
                        else OnPageNavigation(totalPages);
                    }
                };
            });
    }
