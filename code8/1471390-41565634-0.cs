    // Method to prepare the WMI query connection options.
    public static ConnectionOptions PrepareOptions ( )
    {
      ConnectionOptions options = new ConnectionOptions ( );
      options . Impersonation = ImpersonationLevel . Impersonate;
      options . Authentication = AuthenticationLevel . Default;
      options . EnablePrivileges = true;
      return options;
    }
    
    // Method to prepare WMI query management scope.
    public static ManagementScope PrepareScope ( string machineName , ConnectionOptions options , string path  )
    {
      ManagementScope scope = new ManagementScope ( );
      scope . Path = new ManagementPath ( @"\\" + machineName + path );
      scope . Options = options;
      scope . Connect ( );
      return scope;
    }
    
    // Set DNS.
    ConnectionOptions options = PrepareConnectionOptions ( );
    ManagementScope scope = PrepareScope ( Environment . MachineName , options , @"\root\CIMV2" );
    ManagementClass mc = new ManagementClass(scope, "Win32_NetworkAdapterConfiguration");
    ManagementObjectCollection moc = mc.GetInstances();
    foreach (ManagementObject mo in moc)
    {
        if ((bool)mo["IPEnabled"])
        {
            ManagementBaseObject objdns = mo.GetMethodParameters("SetDNSServerSearchOrder");
            if (objdns != null)
            {
                string[] s = { "192.168.XX.X", "XXX.XX.X.XX" };
                objdns["DNSServerSearchOrder"] = s;
                mo.InvokeMethod("SetDNSServerSearchOrder", objdns, null);
