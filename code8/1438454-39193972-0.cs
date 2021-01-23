    public static class Logger
    {
        public static void Log(IServerPath path, string msg)
        {
            //add parameter checking here
            
            string path = path.MapPath("file.txt");
            //actual log goes here
        }
    }
