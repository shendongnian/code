    private static void ShowFileDetails()
    {
        List<string> lstFiles = System.IO.Directory.GetFiles(@"D:\downloads").ToList(); //Need to pass the folder path to get the files.
        foreach (string file in lstFiles)
        {
            System.IO.FileInfo fi = new System.IO.FileInfo(file);
            Console.WriteLine(string.Format("Extension={0}\tFile Name={1}\tFile Size={2} bytes\tFile Path={3}\tCreated On={4}\tModified On={5}",
                                fi.Extension,
                                fi.Name,
                                fi.Length,
                                fi.FullName,
                                fi.CreationTime,
                                fi.LastWriteTime));
        }
        Console.ReadLine();
    }
