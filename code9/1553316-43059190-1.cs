    private void WpfInit()
    {
        Settings.Default.SettingChanging += Settings_SettingsChanging;
    }
    private void Settings_SettingsChanging(Object sender, SettingChangingEventArgs e) {
       var dlgResult = MessageBox.Show("Are you sure?", "Please Confirm...", MessageBoxButton.YesNo);
       if (dlgResult != MessageBoxResult.Yes) {
          e.Cancel = true;
          MessageBox.Show("Change cancelled");
       }
    }
