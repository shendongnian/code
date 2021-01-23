    RegistryKey localMachine;
    if (Directory.Exists("C:\\Windows\\SysWOW64"))
       { localMachine = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64); }
    else { localMachine = Registry.LocalMachine; }
    string productsRoot = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Installer\UserData\S-1-5-18\Products";
    RegistryKey products = localMachine.OpenSubKey(productsRoot);
    string[] productFolders = products.GetSubKeyNames();
