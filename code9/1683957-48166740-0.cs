    string path = @"\SYSTEM\ControlSet001\Control\Class\{4d36e972-e325-11ce-bfc1-08002be10318}\0002";
    using (RegistryKey key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
    {
        using (var subKey = key.OpenSubKey(path, false))
        {
            if (subKey != null)
            {
                return true;
            }
        }
    }
