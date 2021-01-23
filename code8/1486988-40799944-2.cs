    public void WriteMessageWithLineNumbers(string message)
    {
       string path = @"C:\Users\AT\Documents\Visual Studio 2013\Projects\Sample_App\Sample_App\app_data\log.txt"; //File path
       if (File.Exists(path))
       {
         var lines = File.ReadAllLines(path);
         var nextLine = string.Format("{0} - Hello World", lines.Length + 1)
         File.AppendAllLines(path, new[]{ nextLine });
       }
       else
       {
         File.AppendAllLines(path, new[]{ "1 - Hello World!!" });
       }
    }
