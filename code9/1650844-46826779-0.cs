        public static void Main()
        {
    #if DEBUG
            SampleClass sc = new SampleClass();
            sc.Start();
    #else
            ServiceBase[] servicesToRun = new ServiceBase[]
            {
                new SampleService ()
            };
            ServiceBase.Run(servicesToRun);
    #endif
        }
