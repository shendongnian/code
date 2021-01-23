    SystemEvents.PowerModeChanged += SystemEvents_PowerModeChanged;
...
   
    private void SystemEvents_PowerModeChanged(object sender, PowerModeChangedEventArgs e)
    {
        if (e.Mode == PowerModes.Resume)
        {
            _resumed = true;
        }
    }
