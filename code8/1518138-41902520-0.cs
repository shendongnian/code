    [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern bool LogonUser(String lpszUsername, String lpszDomain, String lpszPassword, int dwLogonType, int dwLogonProvider, out SafeTokenHandle phToken);
    LogonUser(userName, domainName, password,
            LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT,
            out safeTokenHandle);
    try
    {
        using (WindowsIdentity newId = new WindowsIdentity(safeTokenHandle.DangerousGetHandle()))
        {
            using (WindowsImpersonationContext impersonatedUser = newId.Impersonate())
            {
                foreach (Computer pc in selectedList)  // selectedList is an ObservableCollection<Computer>
                {
                    string newDir = "//" + pc.Name + txtExtension.Text; // the textbox has /C$/APP_A_DIR in it
                    if (Directory.Exists(newDir))  
                    {
                        DeleteDirectory(newDir);  // <-- this is where the exception happens
                    }
                }
            }
        }
    }
    catch (IOException ex)
    {
        string msg = "There was a file left open, thereby preventing a full deletion of the previous folder, though all contents have been removed.  Do you wish to proceed with installation, or reboot the server and begin again, in order to remove and replace the installation directory?";
        MessageBoxResult result = MessageBox.Show(msg, "Reboot File Server?", MessageBoxButton.OKCancel);
        if (result == MessageBoxResult.OK)
        {
            var psi = new ProcessStartInfo("shutdown","/s /t 0");
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            Process.Start(psi);
        }
        else
        {
            MessageBox.Show("Copying files...");
            FileSystem.CopyDirectory(sourcePath, newDir);
            MessageBox.Show("Completed!");
        }
    }
