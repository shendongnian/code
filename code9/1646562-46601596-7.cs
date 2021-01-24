    try
    {
        // This will throw an exception if the other process has already moved the file - 
        // either FileName no longer exists, or it is locked.
        File.Move(FileName, PendingFileName);
        // If we get this far we know we have exclusive access to the pending file.
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
        // Implement a retry mechanism to try moving the file again.
    }
