    protected override void OnShown(EventArgs e)
    {
        base.OnShown(e);
        
        // get the current screen
        Screen screen = Screen.FromControl(this);
        
        // set Location and Size of your form to fit in the WorkingArea
        Location = new Point(screen.WorkingArea.Left, screen.WorkingArea.Top);
        Size = new Size(screen.WorkingArea.Width, screen.WorkingArea.Height);
    }
