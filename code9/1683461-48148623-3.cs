    var baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, 
                                          RegistryView.Registry64);
    if (baseKey != null)
    {
        var subKey = baseKey.OpenSubKey(subkey, 
                             RegistryKeyPermissionCheck.ReadWriteSubTree, 
                             RegistryRights.FullControl);
        if (subKey != null)
        {
            myKey.SetValue("USERProcessHandleQuota", 50000, RegistryValueKind.DWord);
            myKey.Close();
        }
        baseKey.Close();
    }
