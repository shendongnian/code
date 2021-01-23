        public partial class App : Application
        {
            private static readonly string _MutexID = "MyWPFApp"; // or whatever
            [STAThread]
            public static void Main()
            {
                var application = new App();
                application.InitializeComponent();
                MutexAccessRule allowEveryoneRule = new MutexAccessRule(
                           new SecurityIdentifier(WellKnownSidType.WorldSid, null),
                           MutexRights.FullControl,
                           AccessControlType.Allow);
                MutexSecurity securitySettings = new MutexSecurity();
                securitySettings.AddAccessRule(allowEveryone);
                Mutex globalMutex = null;
                try
                {
                    bool createdNew;
                    globalMutex = new Mutex(false, "Global\\" + _MutexID, out createdNew, securitySettings);
                }
                catch (UnauthorizedAccessException)
                {
                    // ignore
                }
                Mutex localMutex = new Mutex(false, _MutexID);
                try
                {
                    MainWindow mainWin = new MainWindow();
                    application.Run(mainWin);
                }
                finally
                {
                    if (globalMutex != null)
                    {
                        globalMutex.Dispose();
                    }
                    localMutex.Dispose();
                }
            }
        }
