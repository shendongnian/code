        [STAThread]
        static void Main()
        {
            const string MutexName = "8F6F0AC4-B9A1-45fd-A8CF-72F04E6BDE8F";
            try
            {
                Mutex mutex;
                if (!Mutex.TryOpenExisting(MutexName, out mutex))
                {
                    mutex = new Mutex(true,MutexName);
                    var app = new App();
                    app.Run();
                }
                else
                {
                    Environment.Exit(1);
                }
            }
            catch
            {
                Environment.Exit(1);
            }
        }
