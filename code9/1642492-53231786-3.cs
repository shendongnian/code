    using RestartManager;
    
    public static class Test
    {
        public static void Main()
        {
            using (var rm = new RestartManagerSession())
            {
                // add all processes having the name `explorer`
                rm.RegisterProcess(Process.GetProcessesByName("explorer"));
                // you can also add explorer.exe specifically by 
                // using the `RegisterProcessFile()` method
                //rm.RegisterProcessFile(new FileInfo(Path.Combine(
                //  Environment.GetFolderPath(Environment.SpecialFolder.Windows),
                //  "explorer.exe"
                //)));
                rm.Shutdown(RestartManagerSession.ShutdownType.Normal);
                rm.Restart();
            }
        }
    }
