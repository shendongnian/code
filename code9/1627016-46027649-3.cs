        var checkBoxNames = new[]
        {
            "CyberSec", "AutomaticUpdates", "AutoConnect",
            "StartOnStartup", "KillSwitch", "ShowNotifications",
            "StartMinimized", "ShowServerList", "ShowMap",
            "UseCustomDns", "ObfuscatedServersOnly"
        };
        foreach(var path in checkBoxNames)
        {
            var chkBox = settingsView.GetChildWithPath<CheckBox>(CheckBox.IsCheckedProperty, path);
            if(chkBox != null && chkBox.IsEnabled)
                chkBox.SimulateClick();
        }
