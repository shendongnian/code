    using RestartManager;
    
    public static class Test
    {
        public static void Main()
        {
            using (var rm = new RestartManagerSession())
            {
                rm.RegisterProcess(Process.GetProcessesByName("explorer"));
                rm.Shutdown(RestartManagerSession.ShutdownType.Normal);
                rm.Restart();
            }
        }
    }
