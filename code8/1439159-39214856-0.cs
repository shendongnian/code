    string Owner = "";
    string Company = "";
    OperatingSystem osInfo = System.Environment.OSVersion;
    if (osInfo.Platform == PlatformID.Win32Windows)
    {
        // Windows 98                                                
        Owner = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion", "RegisteredOwner", "Unknown");
        Company = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion", "RegisteredOrganization", "Unknown");
    }
    else if (osInfo.Platform == PlatformID.Win32NT)
    {
        // for NT+                
        RegistryKey localKey;
        if (Environment.Is64BitOperatingSystem)
            localKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
        else
            localKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
        Owner = localKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion").GetValue("RegisteredOwner", "Unknown").ToString();
        Company = localKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion").GetValue("RegisteredOrganization", "Unknown").ToString();
    }
    lblRegOwner.Text = Owner;
    lblRegOrg.Text = Company;
