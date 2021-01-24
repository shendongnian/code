        public static class FileSystem
        {
            public static void RunAsAdministrator(this Process process, 
                                                  string arguments = "")
            {
                if (process == null)
                {
                    throw new ArgumentNullException(nameof(process));
                }
                ProcessStartInfo startInfo = new 
                                 ProcessStartInfo(process.MainModule.FileName)
                {
                    Verb = @"runas",
                    Arguments = arguments
                };
            Process.Start(startInfo);
        
        public static void TakeOwnership(string path)
        {
            if (AppDomain.CurrentDomain.IsAdministrator())
            {
                using (new PrivilegeEnabler(Process.GetCurrentProcess(), Privilege.TakeOwnership))
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(path);
                    DirectorySecurity directorySecurity = directoryInfo.GetAccessControl();
                    if (directorySecurity == null)
                    {
                        return;
                    }
                    directorySecurity.SetOwner(WindowsIdentity.GetCurrent().User);
                    Directory.SetAccessControl(path, directorySecurity);
                }
            }
            else
            {
                Process.GetCurrentProcess().RunAsAdministrator();
            }
        }
    }
    public static bool IsAdministrator(this AppDomain threadDomain)
    {
        threadDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
        WindowsPrincipal currentPrincipal = (WindowsPrincipal) Thread.CurrentPrincipal;
        if (currentPrincipal.IsInRole(WindowsBuiltInRole.Administrator) || currentPrincipal.IsInRole((int) WellKnownSidType.AccountDomainAdminsSid))
        {
            return true;
        }
        using (WindowsIdentity windowsIdentity = WindowsIdentity.GetCurrent())
        {
            return windowsIdentity.Groups?.Any(windowsIdentityGroup => windowsIdentityGroup.Value.Equals(@"S-1-5-32-544")
                                                                        || windowsIdentityGroup.Value.EndsWith(@"500")
                                                                        || windowsIdentityGroup.Value.EndsWith(@"512")) == true;
        }
    }
