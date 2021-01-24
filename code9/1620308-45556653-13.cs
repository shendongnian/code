        public static int CountFiles2(string path, string folderToSearch)
        {
            int fileCount = 0;
            var dirs = Directory.EnumerateDirectories(path, folderToSearch, SearchOption.AllDirectories).ToList();
            foreach (string dir in dirs)
            {
                var files = Directory.EnumerateFiles(dir, "*.*", SearchOption.AllDirectories);
                if (files != null)
                    fileCount += files.Count();
            }
            return fileCount;
        }
