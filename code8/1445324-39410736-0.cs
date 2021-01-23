    private static ReaderWriterLockSlim readerWriterLockSlim = new ReaderWriterLockSlim();
    public static void AppendToFile(string path, string text) 
    {
        // Set to locked (other thread will freeze here until object is unlocked
        readerWriterLockSlim.EnterWriteLock();
        try
        {
            // Write that will append to the file
            using (StreamWriter sw = File.AppendText(path))
            {
                // append the text
                sw.WriteLine(text);
                sw.Close();
            }
        }
        finally
        {
            // Clear the lock
            readerWriterLockSlim.ExitWriteLock();
        }
    }
