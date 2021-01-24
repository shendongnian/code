    private void btnRemind_Click(object sender, RoutedEventArgs e)
    {
        var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        if (Window.GetWindow(this).Title == "ANM")
            config.AppSettings.Settings["nIntervalDeTimpReminderANM"].Value = textBox.Text;
        else if (Window.GetWindow(this).Title == "CAS")
            config.AppSettings.Settings["nIntervalDeTimpReminderCAS"].Value = textBox.Text;
        else if (Window.GetWindow(this).Title == "MS")
            config.AppSettings.Settings["nIntervalDeTimpReminderMS"].Value = textBox.Text;
        config.Save(ConfigurationSaveMode.Modified);
        ConfigurationManager.RefreshSection("appSettings");
        Window.GetWindow(this).Hide();
        //STOP the old timer here:
        if (dispatcherTimer != null)
        {
            dispatcherTimer.Stop();
        }
        InitTimer();
    }
