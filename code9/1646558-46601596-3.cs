    try
    {
        // This will throw an exception if the other process has already moved the file.
        File.Move(FileName, PendingFileName);
        using (FileStream fileStream = new FileStream(PendingFileName, FileMode.Open, FileAccess.Write, FileShare.Read))
        {
            // Read from or write to file.
        }
        File.Delete(PendingFileName);
    }
    catch (IOException ex)
    {
        // The file is locked by the other process. 
        // Some options here:
        // Log exception.
        // Ignore exception and carry on.
        // Implement a retry mechanism to try opening the file again.
    }
