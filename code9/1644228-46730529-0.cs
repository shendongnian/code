    try {
         new MigrationsWrapper(AppManager.ConnectionString).MigrateToLatestVersion();
    }
    catch (Exception ex) 
    {
        
    }
    LatestVersionNumber = new MigrationsWrapper(AppManager.ConnectionStringADO).LatestVersionNumber;
    CurrentVersionNumber = new MigrationsWrapper(AppManager.ConnectionStringADO).CurrentVersionNumber;
    if (LatestVersionNumber > CurrentVersionNumber) {
    
     string applicationName = ConfigurationManager.AppSettings["ApplicationName"].ToString();
     string uninstallString = GetUninstallRegistryKeyByProductName(applicationName);
     if (uninstallString != string.Empty) {
          System.Diagnostics.Process process = new System.Diagnostics.Process();
          System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
          startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
          startInfo.FileName = "cmd.exe";
          startInfo.Arguments = "/c " + uninstallString;
          process.StartInfo = startInfo;
          process.Start();
    
     }
    } else {
     // Successfull
    }
