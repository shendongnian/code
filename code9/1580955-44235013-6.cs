    public static class CustomLogger
    {
        private static readonly LogWriterFactory LogWriterFactory = new LogWriterFactory(ConfigurationSourceFactory.Create());
        private static readonly object Locker = new object();
        public static void Write(string message, string category)
        {
            lock (Locker)
            {
                using (var logWriter = LogWriterFactory.Create())
                {
                    logWriter.Write(message, category);
                }
            }
        }
    }
    CustomLogger.Write("Test 1", "General");
    CustomLogger.Write("Test 2", "General");
