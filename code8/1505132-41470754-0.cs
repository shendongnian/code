    public static string uniqueFolder = String.Empty;
    . . .
    internal static void SetUniqueFolder(string _unit)
    {
        uniqueFolder = String.Format("{0}\\{1}", _unit.ToUpper(), GetYYYYMMDDHHMM());
    }
    
    internal static void ConditionallyCreateDirectory(string dirName)
    {
        Directory.CreateDirectory(dirName);
    }
