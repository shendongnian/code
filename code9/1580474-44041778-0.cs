    public static bool Debug = false;
    public static string FilePath()
    {
        var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        var filePath = string.Empty;
        if(Debug)
           filePath = Path.GetFullPath(string.Format(@"{0}\Settings\Config.local.json", baseDirectory));
        else
           filePath = Path.GetFullPath(string.Format(@"{0}\Settings\Config.json", baseDirectory));
        return filePath;
    }
