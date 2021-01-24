    var option = allDirs ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
    IEnumerable<FileInfo> list1 = (new DirectoryInfo(pathA)).GetFiles("*.*", option);
    IEnumerable<FileInfo> list2 = (new DirectoryInfo(pathB)).GetFiles("*.*", option);
    //A custom file comparer defined later
    FileCompare myFileCompare = new FileCompare();
    bool areIdentical = list1.SequenceEqual(list2, myFileCompare);
