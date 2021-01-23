    string registry_key = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
    using(Microsoft.Win32.RegistryKey key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(registry_key))
    {
        foreach(string subkey_name in key.GetSubKeyNames())
        {
            using(RegistryKey subkey = key.OpenSubKey(subkey_name))
            {
                if(subkey!=null)
                       Console.WriteLine(subkey.GetValue("DisplayName"));
            }
        }
    }
