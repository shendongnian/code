    public static class Logger 
    {
        static string uripath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\Results.txt";
        public static string logLocation = new Uri(uripath).LocalPath;
                
        static Logger() {
            using (File.Create(logLocation))
            { }
            using (var fs = new FileStream(logLocation, FileMode.Truncate)){}
        }
        public static void ResultLog(int testcasenum,String Expected,String Actual, String textResult)
        {
            FileInfo outtxt = new FileInfo(logLocation);
            StreamWriter logline = outtxt.AppendText();
            
            logline.WriteLine("Test Case : " + testcasenum);
            logline.WriteLine("{0},{1},{2}", "Expected - "+Expected, "Actual - "+Actual, "Result - "+textResult);
            // flush and close file.
            logline.Flush(); logline.Close();
            
        }
    }
