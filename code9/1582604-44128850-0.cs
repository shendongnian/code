    public event EventHandler SettingsApplied;
    
    public void NotifySettingsApplied(EventArgs e)
    {
        if(SettingsApplied != null)
            SettingsApplied(this, e);
    }
    public void Apply_OnClick(object sender, EventArgs e)
    {
        //trigger event here to notify main form
        NotifySettingsApplied(e);
    }
