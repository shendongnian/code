        public static int CountFiles(string path, string folderToSearch)
        {
            int fileCount = 0;
            var files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).ToList();
            foreach (string file in files)
            {
                if (Path.GetDirectoryName(file) == folderToSearch)
                    fileCount++;
            }
            return fileCount;
        }
