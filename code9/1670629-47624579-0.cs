    protected override void OnClosing(CancelEventArgs e)
    {
        Properties.Settings.Default.Save();
        base.OnClosing(e); 
    }
