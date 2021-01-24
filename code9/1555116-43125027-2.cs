     public static void OnCreated(object source, FileSystemEventArgs e)
        {
           var processor = new FileProcessor();
           processor.ProcessFile(e.FullPath);
        }
