    public class Tester
    {
        public Tester()
        {
            AppConfig.LogSettings.FileSize = 5; // compile error 
            Console.WriteLine(AppConfig.LogSettings.FileSize); // works
        }
    }
    
    public static class AppConfig
    {
        // just an example of setting the value in the outer class
        private static void SetFileSize(int size)
        {
            fileSize = size; // internal only setting works
        }
        
        private static int fileSize; // a member of AppConfig still
        public static class LogSettings
        {
            public static int FileSize
            {
                get { return fileSize; } // internal classes can access private members of the outer class
            }
        }
    }
