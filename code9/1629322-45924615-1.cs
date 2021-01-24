    public static bool CopyDir(string sPath, string dPath)
    {
        try
        {
             foreach (string dirPath in Directory.GetDirectories(sPath, "*",
                    SearchOption.AllDirectories))
                    Directory.CreateDirectory(dirPath.Replace(sPath, dPath));
             foreach (string newPath in Directory.GetFiles(sPath, "*.*",
                    SearchOption.AllDirectories))
                    File.Copy(newPath, newPath.Replace(sPath, dPath), true);
        }
        catch // this is no use because the Exception is empty.
        {
            return false;
        }
        return false; //the app keeps executing to here and I don't know why
    }
