    public static Restarting = false;
....
    if( !Restarting && Process.GetProcessesByName(Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly().Location)).Count() > 1)
                    {
                        MessageBox.Show("Multiple instances!");
                        Process.GetCurrentProcess().Kill();
                    }
