    // updated process start
    ProcessStartInfo psi = new ProcessStartInfo("your/WPF/application.exe");
    psi.Arguments = "-u " + Process.GetCurrentProcess().Id;
    // fill up rest of the properties you need 
    Process.Start(psi);
    // wpf application's entry point
    void Main(string[] args)
    {
        string updaterProcessIdstr = string.Empty;
        for (int i = 0; i < args.Length; i++)
        {
            if(args[i] == "-u")
            {
                updaterProcessIdstr = args[i + 1];
                i++;
            }
        }
        int pid = int.Parse(updaterProcessIdstr);
        Process updaterProcess = Process.GetProcessById(pid);
        // do some validation here
        // send something to stdin and read from stdout 
        // to determine if it was started from that updater.
    }
