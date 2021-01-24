    protected static float CalculateFolderSize(string folder)
    {
        float folderSize = 0.0f;
        try
        {
            //Checks if the path is valid or not
            if (!Directory.Exists(folder))
                return folderSize;
            else
            {
                try
                {
                    foreach (string file in Directory.GetFiles(folder))
                    {
                        if (File.Exists(file))
                        {
                            FileInfo finfo = new FileInfo(file);
                            folderSize += finfo.Length;
                        }
                    }
    
                    foreach (string dir in Directory.GetDirectories(folder))
                        folderSize += CalculateFolderSize(dir);
                }
                catch (NotSupportedException e)
                {
                    Console.WriteLine("Unable to calculate folder size: {0}", e.Message);
                }
            }
        }
        catch (UnauthorizedAccessException e)
        {
            Console.WriteLine("Unable to calculate folder size: {0}", e.Message);
        }
        return folderSize;
    }
