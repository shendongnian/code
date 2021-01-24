    #load "extensions.csx"
    public static void Run(TimerInfo timer, TraceWriter log)
    {
        log.Info("test".MyToUpperExtension());
    }
