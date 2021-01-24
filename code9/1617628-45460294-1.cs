    private void Application_Startup(object sender, StartupEventArgs e)
    {
        if (!IsRunAsAdmin())
        {
            // here you should log the special folder path 
            MessageBox.Show(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
            // Launch itself as administrator 
            ProcessStartInfo proc = new ProcessStartInfo();
            proc.UseShellExecute = true;
            proc.WorkingDirectory = Environment.CurrentDirectory;
            proc.FileName = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            proc.Verb = "runas";
            try
            {
                Process.Start(proc);
            }
            catch
            {
                // The user refused the elevation. 
                // Do nothing and return directly ... 
                return;
            }
            System.Windows.Application.Current.Shutdown();  // Quit itself 
        }
        else
        {
            MessageBox.Show("The process is running as administrator", "UAC");
        }
    }
    internal bool IsRunAsAdmin()
    {
        WindowsIdentity id = WindowsIdentity.GetCurrent();
        WindowsPrincipal principal = new WindowsPrincipal(id);
        return principal.IsInRole(WindowsBuiltInRole.Administrator);
    }
