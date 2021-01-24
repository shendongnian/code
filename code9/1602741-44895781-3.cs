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
            using (TrayManager trayManager = new TrayManager())
            {
                TrayOnlyApplication app = new TrayOnlyApplication();
                app.StartupNextInstance += (s, e) => trayManager
                    .SetToolTipText(e.CommandLine.Count > 0 ? e.CommandLine[0] : "<no value given>");
                app.Run(args);
            }
        }
    }
