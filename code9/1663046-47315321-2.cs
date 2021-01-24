    static void CopyNewestFileToLocation(string fileOne, string fileTwo, string destination)
    {
        // Argument validation
        if (fileOne == null) throw new ArgumentNullException(nameof(fileOne));
        if (fileTwo == null) throw new ArgumentNullException(nameof(fileTwo));
        if (destination == null) throw new ArgumentNullException(nameof(destination));
        if (!File.Exists(fileOne)) throw new FileNotFoundException(
            "File specified for fileOne parameter does not exist", fileOne);
        if (!File.Exists(fileTwo)) throw new FileNotFoundException(
            "File specified for fileTwo parameter does not exist", fileTwo);
        if (!Directory.Exists(destination))
        {
            try
            {
                Directory.CreateDirectory(destination);
            }
            catch (Exception e)
            {
                var msg = $"Unable to create specified directory: {destination}" + 
                          $"\nException Details:\n{e}";
                throw new ArgumentException(msg);
            }
        }
        // Find newest file and copy it
        if (File.GetLastWriteTime(fileOne) > File.GetLastWriteTime(fileTwo))
        {
            File.Copy(fileOne, Path.Combine(destination, Path.GetFileName(fileOne)));
        }
        else // TODO: decide what to do if they're equal
        {
            File.Copy(fileTwo, Path.Combine(destination, Path.GetFileName(fileTwo)));
        }
    }
