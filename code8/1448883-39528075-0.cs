    public class Logger
    {
        private static string _appDataPath =
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
    
        private static string _logPath = _appDataPath + "\\MyApp\\Log";
        private static string _logFileName = "logfile.txt";
    
        public static void log(string lines)
        {
            if (!Directory.Exists(_logPath))
            {
                Directory.CreateDirectory(_logPath);
            }
    
            using (StreamWriter file = new StreamWriter(Path.Combine(_logPath, _logFileName)))
            {
                file.WriteLine(lines);
                file.Close();
            };
        }
    }
