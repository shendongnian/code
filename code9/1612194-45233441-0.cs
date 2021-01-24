    if (allDirs)
    {
        IEnumerable<FileInfo> list1 = dir1.GetFiles("*.*", SearchOption.AllDirectories);
        IEnumerable<FileInfo> list2 = dir2.GetFiles("*.*", SearchOption.AllDirectories);
    }
    else
    {
        IEnumerable<FileInfo> list1 = dir1.GetFiles("*.*", SearchOption.TopDirectoryOnly);
        IEnumerable<FileInfo> list2 = dir2.GetFiles("*.*", SearchOption.TopDirectoryOnly);
    }
