    static void CopyNewestFileToLocation(string fileOne, string fileTwo, string destination)
    {
        if (fileOne == null) throw new ArgumentNullException(nameof(fileOne));
        if (fileTwo == null) throw new ArgumentNullException(nameof(fileTwo));
        if (destination == null) throw new ArgumentNullException(nameof(destination));
        if (!File.Exists(fileOne)) throw new FileNotFoundException(nameof(fileOne));
        if (!File.Exists(fileTwo)) throw new FileNotFoundException(nameof(fileTwo));
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
        if (File.GetLastWriteTime(fileOne) > File.GetLastWriteTime(fileTwo))
        {
            File.Copy(fileOne, Path.Combine(destination, Path.GetFileName(fileOne)));
        }
        else
        {
            File.Copy(fileTwo, Path.Combine(destination, Path.GetFileName(fileTwo)));
        }
    }
