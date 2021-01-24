            List<string> dir = new List<string>();
            System.IO.DriveInfo di = new System.IO.DriveInfo(@"D:\");
            System.IO.DirectoryInfo dirInfo = di.RootDirectory;
            System.IO.DirectoryInfo[] dirInfos = dirInfo.GetDirectories("*.*");
            foreach (System.IO.DirectoryInfo d in dirInfos)
            {
                dir.Add(d.Name);
            }
