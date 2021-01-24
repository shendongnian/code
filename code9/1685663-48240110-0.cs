    DateTime dtLastWrite = DateTime.Now;
    private static void OnChanged(object source, FileSystemEventArgs e)
    {
       dtLastWrite = DateTime.Now();
    }
    private static void OnChanged(object source, FileSystemEventArgs e)
    {
       if (DateTime.Now.Subtract(dtLastWrite).TotalSeconds > 5)
          ReadTheFileNow(); //start to read the file now.
       else
          dtLastWrite = DateTime.Now;
    }
