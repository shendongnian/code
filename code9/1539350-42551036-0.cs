    public void OnResetClientSettingsCommandExecute()
    {
        var defaultSettings = Global.DbContext.Settings.FirstOrDefault(c => c.client_id == 1);
        if (defaultSettings == null) return;
        var selectedClientSettings = Global.DbContext.Settings.FirstOrDefault(c => c.client_id == SelectedClient.client_id);
        selectedClientSettings.serviceName = defaultSettings.serviceName;
        selectedClientSettings.write_delay = defaultSettings.write_delay;
        // etc...
    
        Global.DbContext.SaveChanges();
    }
