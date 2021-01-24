    try
    {
        using (FileStream fileStream = new FileStream(FileName, FileMode.Open, FileAccess.Write, FileShare.Read))
        {
            // Write to file.
        }
    }
    catch (IOException ex)
    {
        // The file is locked by the other process. 
        // Some options here:
        // Log exception.
        // Ignore exception and carry on.
        // Implement a retry mechanism to try opening the file again.
    }
