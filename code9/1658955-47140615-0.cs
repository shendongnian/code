    public static int docount();
    {
    int directoryCount = Directory.GetDirectories(tets, " * ", SearchOption.AllDirectories).Length;
    int fileCount = Directory.GetFiles(tets, "*", SearchOption.AllDirectories).Length;
    count = directoryCount + fileCount;
    }
