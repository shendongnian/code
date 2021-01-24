    public void DoCompare(string pathA, string pathB, bool allDirs)
    {
        DirectoryInfo dir1 = new DirectoryInfo(pathA);
        DirectoryInfo dir2 = new DirectoryInfo(pathB);
        IEnumerable<FileInfo> list1; // declare list1 here
        IEnumerable<FileInfo> list2; // declare list2 here
        if (allDirs)
        {
            list1 = dir1.GetFiles("*.*", SearchOption.AllDirectories);
            list2 = dir2.GetFiles("*.*", SearchOption.AllDirectories);
        }
        else
        {
            list1 = dir1.GetFiles("*.*", SearchOption.TopDirectoryOnly);
            list2 = dir2.GetFiles("*.*", SearchOption.TopDirectoryOnly);
        }
        //A custom file comparer defined later
        FileCompare myFileCompare = new FileCompare();
        bool areIdentical = list1.SequenceEqual(list2, myFileCompare);
    }
