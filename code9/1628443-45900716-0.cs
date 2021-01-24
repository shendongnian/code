    private delegate bool ConsoleEventDelegate(int eventType);
    
    public static Main(string[] args)
    {
                SetConsoleCtrlHandler(ConsoleEventCallback, true);
                AppDomain.CurrentDomain.UnhandledException += Reset;
                AppDomain.CurrentDomain.ProcessExit += Exit;
                AppDomain.CurrentDomain.DomainUnload += Exit;
    }
    
            private static void Exit(object sender, EventArgs e)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"http://10.0.0.1/?p=Logout&HOSTNAME={HOSTNAME}&IP={IP}&USERNAME={USERNAME}&HASH={HASH}");
            request.AutomaticDecompression = DecompressionMethods.GZip;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse());
            }
    
            private static void Reset(object sender, UnhandledExceptionEventArgs e)
            {
                Exit(null, null);
            }
    
            private static bool ConsoleEventCallback(int eventType = 0)
            {
                Exit(null, null);
                return false;
            }
