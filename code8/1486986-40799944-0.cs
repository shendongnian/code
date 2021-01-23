    public void WriteMessage(string message)
    {
       string path = @"C:\Users\AT\Documents\Visual Studio 2013\Projects\Sample_App\Sample_App\app_data\log.txt"; //File path
    
       if (File.Exists(path))
       {
         File.AppendAllLines(path, new[]{ "Another line added - Hello world" });
       }
       else
       {
         File.AppendAllLines(path, new[]{ "Hello World!!" });
       }
    }
