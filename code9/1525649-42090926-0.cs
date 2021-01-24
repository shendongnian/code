    using Microsoft.Win32;
    public List<string> GetAllInstalledPrograms()
        {
            List<string> res = new List<string>();
            string registry_key = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            using (Microsoft.Win32.RegistryKey key = Registry.LocalMachine.OpenSubKey(registry_key))
            {
                foreach (string subkey_name in key.GetSubKeyNames())
                {
                    using (RegistryKey subkey = key.OpenSubKey(subkey_name))
                    {
                        res.Add(subkey.GetValue("DisplayName").ToString());
                    }
                }
            }
            return res;
        }
