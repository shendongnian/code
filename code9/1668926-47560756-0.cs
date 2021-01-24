    private static Mutex _mutex = new Mutex(true, "AppMutex");
    static void Main()
    {
        if(!_mutex.WaitOne(0, true))
        {
            return;
        }
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new AppForm());
    }
