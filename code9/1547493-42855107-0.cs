        private static void Main(string[] _arguments)
        {
            // ... some general code here
            StartDebug(_arguments);
            StartRelease();
        }
        [Conditional("DEBUG")]
        private static void StartDebug(string[] _arguments)
        {
            MessageBox.Show("Starting in debug mode");
            try
            {
                Service1 service = new Service1();
                service.Start(_arguments);
                while (true)
                {
                    Thread.Sleep(100);
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }            
        }
        [Conditional("RELEASE")]
        private static void StartRelease()
        {
            ServiceBase[] servicesToRun = { new Service1() };
            ServiceBase.Run(servicesToRun);
        }
