    public static class Log
    {
        public static string _file = "log.txt";
        public static object _locked = new object();
    
        public static void AppendToLog(string text)
        {
             lock(_locked)
             {
                 string path = Server.MapPath("~/APP_DATA");
                 File.AppendAllText(Path.Combine(path, _file), text + Environment.NewLine);
             } 
        }
    }
