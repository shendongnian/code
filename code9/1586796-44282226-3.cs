    public static string FindFirstFile(string path, string searchPattern)
    {
        string[] files;
    
        try
        {
            // Exception could occur due to insufficient permission.
            files = Directory.GetFiles(path, searchPattern, SearchOption.TopDirectoryOnly);
        }
        catch (Exception)
        {
            return string.Empty;
        }
    
        if (files.Length > 0)
        {
            return files[0];
        }
        else
        {
            // Otherwise find all directories.
            string[] directories;
    
            try
            {
                // Exception could occur due to insufficient permission.
                directories = Directory.GetDirectories(path);
            }
            catch (Exception)
            {
                return string.Empty;
            }
    
            // Iterate through each directory and call the method recursivly.
            foreach (string directory in directories)
            {
                string file = FindFirstFile(directory, searchPattern);
    
                // If we found a file, return it (and break the recursion).
                if (file != string.Empty)
                {
                    return file;
                }
            }
        }
    
        return string.Empty;
    }
