    using RestartManager;
    
    public static class Test
    {
        public static void Main()
        {
            using (var rm = new RestartManagerSession())
            {
                // add all processes having the name `explorer`
                // you can also add explorer.exe specifically by 
                // using the `RegisterProcessFile()` method
                rm.RegisterProcess(Process.GetProcessesByName("explorer"));
                rm.Shutdown(RestartManagerSession.ShutdownType.Normal);
                rm.Restart();
            }
        }
    }
