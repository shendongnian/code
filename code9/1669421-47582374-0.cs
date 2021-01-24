    public void AttachMenuStripButtonHandlers(
        Button btn, 
        Form form, 
        string enterText,
        string leaveText,
        string tooltip) {
        btn.Click += (sender, args) => {
            form.Visible = true;
            form.Activate();
        };
        btn.MouseEnter += (sender, args) => {
            btn.Text = enterText;
        };
        btn.MouseLeave += (sender, args) => {
            btn.Text = leaveText;
        };
        new ToolTip().SetToolTip(btn, tooltip);
    }
