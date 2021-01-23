    public class Abc
    {
        static Abc() { ServerPath = new ServerPath(); }
    
        public static IServerPath ServerPath { get; set; }
    
        public static void log(string msg) {
            //Read on Write on path;
            string path = getPath(ServerPath);
        }
    
        public static string getPath(IServerPath path) {
            return path.MapPath("file.txt");
        }
    }
