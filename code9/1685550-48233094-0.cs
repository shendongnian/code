    DirectoryInfo dir = new DirectoryInfo(folder);
    FileInfo[] AFiles = dir.GetFiles("*AD");
    FileInfo[] BFiles = dir.GetFiles("*AC");
    while (AFiles.Count() != 0 && BFiles.Count() != 0)
    {
        System.Threading.Thread.Sleep(50000);
        Console.WriteLine("Please Wait...");
        AFiles = dir.GetFiles("*AD");
        BFiles = dir.GetFiles("*AC");
        while (AFiles.Count() == 0 && BFiles.Count() == 0)
        {
            Console.WriteLine("Done.. both files have been removed");
        }
    } 
