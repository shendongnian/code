    public static class Logger
    {
            /// <summary>
            /// Log data into text file
            /// </summary>
            /// <param name="text"></param>
            public static void Log(string text)
            {
                System.IO.File.AppendAllText(System.AppDomain.CurrentDomain.BaseDirectory + "\\Log\\Loginfo.txt", text +Environment.NewLine);
            }
     }
