    using(Microsoft.Win32.RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall"))
    {
        foreach(string skn in key.GetSubKeyNames())
        {
            using(RegistryKey subkey = key.OpenSubKey(skn))
            {
                if(subkey.GetValue("DisplayName").Contains("Adobe PDF")) {
                   // Process accordingly
                }
            }
        }
    }
