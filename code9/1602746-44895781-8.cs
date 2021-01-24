    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            TrayManager trayManager = null;
            TrayOnlyApplication app = new TrayOnlyApplication();
            // Startup is raised only when no other instance of the
            // program is already running.
            app.Startup += (s, e) => trayManager = new TrayManager();
            // StartNextInstance is run when the program if a
            // previously -run instance is still running.
            app.StartupNextInstance += (s, e) => trayManager
                .SetToolTipText(e.CommandLine.Count > 0 ? e.CommandLine[0] : "<no value given>");
            try
            {
                app.Run(args);
            }
            finally
            {
                trayManager?.Dispose();
            }
        }
    }
