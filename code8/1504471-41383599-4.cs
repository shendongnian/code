    public List<MyItem> GetListapp()
    {
        List<MyItem> items = new List<MyItem>();
        string registry_key = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
        using (RegistryKey key = Registry.LocalMachine.OpenSubKey(registry_key))
        {
            foreach (string sbnm in key.GetSubKeyNames())
            {
                using (RegistryKey subkey = key.OpenSubKey(sbnm))
                {
                    string appVersion = (string)subkey.GetValue("DisplayVersion");
                    String app = Convert.ToString(subkey.GetValue("DisplayName"));
                    if (app != "")
                        items.Add(new MyItem() { DisplayName = app, DisplayVersion = appVersion });
                }
            }
        }
        return items;
    }
