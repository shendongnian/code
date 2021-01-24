        static long getFolderSize(string path)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            long b = 0;
            foreach(FileInfo fi in dirInfo.EnumerateFiles("*",SearchOption.AllDirectories))
            {
                b += fi.Length;
            }
            return b;
        }
