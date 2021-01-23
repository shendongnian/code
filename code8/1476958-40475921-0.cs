    // Define the event handlers.
    private static void OnChanged(object source, FileSystemEventArgs e)
    {
        // Specify what is done when a file is changed, created, or deleted.
       if(!System.IO.FileInfo.IsReadOnly) changedToWritable = true;
    }
