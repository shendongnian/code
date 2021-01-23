    public void InitializeAppArguments()
    {
        string[] args = Environment.GetCommandLineArgs();
        // Minimize window on app startup to tray 
        // if user put first argument "--minimize-to-tray" on the app
        //
        if (args.Length >= 2)
        {
            if (args[1] == "--minimize-to-tray")
            {
                this.WindowState = WindowState.Normal; // Fixed the problem
                this.Hide();
                this.StateChanged += MainWindow_StateChanged;
            }
        }
    }
