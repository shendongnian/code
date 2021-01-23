    static bool TryGetKey(out string result)
    {
        result = null;
        try
        {
            using (RegistryKey Adapter = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Class\{4d36e972-e325-11ce-bfc1-08002be10318}", true))
            {
                foreach (string Keyname in Adapter.GetSubKeyNames())
                {
                    RegistryKey Key = Adapter.OpenSubKey(Keyname);
                      
                    if (Key.GetValue("DriverDesc").ToString() != "somename")
                    {
                        result = Key.GetValue("ComponentId").ToString();
                        return true;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Trace.WriteLine(ex.Message);
        }
        return false;
    }
