    private static bool GetDelayedStatus(string serviceName, string machineName)
    {
        using (var regKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, machineName))
        {
            using (RegistryKey serviceKey = regKey.OpenSubKey(@"System\CurrentControlSet\Services\" + serviceName, true))
            {
                int startMode = (int)serviceKey.GetValue("Start", 0, RegistryValueOptions.None);
                int delayedAutostart = (int)serviceKey.GetValue("DelayedAutostart", 0, RegistryValueOptions.None);
                return startMode == 2 && delayedAutostart == 1;
            }
        }
    }
