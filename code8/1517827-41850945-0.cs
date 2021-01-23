    protected override void OnCommitted(System.Collections.IDictionary savedState)
    {
      base.OnCommitted(savedState);
      string regKey = "SYSTEM\\CurrentControlSet\\Services\\MyServiceName";
      var key = Registry.LocalMachine.OpenSubKey(regKey, RegistryKeyPermissionCheck.ReadWriteSubTree)
              ?? Registry.LocalMachine.CreateSubKey(regKey, RegistryKeyPermissionCheck.ReadWriteSubTree);
     // might need to check the result, should be hex 110 or Decimal 272
     key.SetValue("Type", 272, RegistryValueKind.DWord); 
    }
