	// These references are needed:
    // using System.Reflection;
    // using System.Deployment.Application;
    // using System.IO;
    // using Microsoft.Win32;
    private static void SetAddRemoveProgramsIcon(string iconName)
    {
        // only run if deployed
        if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed && ApplicationDeployment.CurrentDeployment.IsFirstRun)
        {
            try
            {
                string assemblyTitle="";
                object[] titleAttributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), true);
                if (titleAttributes.Length > 0 && titleAttributes[0] is AssemblyTitleAttribute)
                {
                    assemblyTitle = (titleAttributes[0] as AssemblyTitleAttribute).Title;
                }
                string iconSourcePath = Path.Combine(System.Windows.Forms.Application.StartupPath, iconName);
                if (!File.Exists(iconSourcePath))
                {
                    return;
                }
                RegistryKey myUninstallKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall");
                string[] mySubKeyNames = myUninstallKey.GetSubKeyNames();
                for (int i = 0; i < mySubKeyNames.Length; i++)
                {
                    RegistryKey myKey = myUninstallKey.OpenSubKey(mySubKeyNames[i], true);
                    object myValue = myKey.GetValue("DisplayName");
                    if (myValue != null && myValue.ToString() == assemblyTitle)
                    {
                        myKey.SetValue("DisplayIcon", iconSourcePath);
                        break;
                    }
                }
            }
            catch (Exception) { }
        }
        return;
    }
		
