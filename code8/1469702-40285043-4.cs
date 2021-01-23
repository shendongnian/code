    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        var notepad = System.Diagnostics.Process.GetProcessesByName("notepad")
                            .FirstOrDefault();
        if (notepad != null)
        {
            var notepadMainWindow = notepad.MainWindowHandle;
            var notepadElement = AutomationElement.FromHandle(notepadMainWindow);
            Automation.AddAutomationEventHandler(
                WindowPattern.WindowOpenedEvent, notepadElement,
                TreeScope.Subtree, (s, e) =>
                {
                    var element = s as AutomationElement;
                    if (element.Current.Name == "Page Setup")
                    {
                        //Page setup opened.
                        this.Invoke(new Action(() =>
                        {
                            this.Text = "Page Setup Opened";
                        }));
                        Automation.AddAutomationEventHandler(
                            WindowPattern.WindowClosedEvent, element,
                            TreeScope.Subtree, (ss, ee) =>
                            {
                                //Page setup closed.
                                this.Invoke(new Action(() =>
                                {
                                    this.Text = "Closed";
                                }));
                            });
                    }
                });
        }
    }
<!---->
    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        Automation.RemoveAllEventHandlers();
        base.OnFormClosing(e);
    }
