    static void Main(string[] args)
    {
        DirectoryInfo dir = new DirectoryInfo(@"C:\to\your\path");
        FileInfo[] files = dir.GetFiles("*.mp4");
    
        var totalDuration = files.Sum(v => GetVideoDuration(v.FullName));
    }
    
    public static double GetVideoDuration(string filePath)
    {
        using (var shell = ShellObject.FromParsingName(filePath))
        {
            IShellProperty prop = shell.Properties.System.Media.Duration;
            var t = (ulong)prop.ValueAsObject;
            return TimeSpan.FromTicks((long)t).TotalMilliseconds;
        }
    }
