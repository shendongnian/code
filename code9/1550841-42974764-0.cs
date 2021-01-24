    public static class Logger
    {
         public static Action<string> Verbose { get; set; }
         public static Action<string> Warn { get; set; }
         public static Action<string> Error { get; set; }
    }
