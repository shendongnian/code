    public void SetDalayedAutoStart(string machineName, string serviceName)
    {
        using (var regKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, machineName))
        {
            using (RegistryKey serviceKey = regKey.OpenSubKey(@"System\CurrentControlSet\Services\" + serviceName, true))
            {
                serviceKey.SetValue("DelayedAutostart", 1, RegistryValueKind.DWord);
            }
        }
    }
