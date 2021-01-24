        public static int CountFiles(string path, string folderToSearch)
        {
            int fileCount = 0;
            var files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).ToList();
            foreach (string file in files)
            {
                string folder = new DirectoryInfo(Path.GetDirectoryName(file)).Name;
                if (folder == folderToSearch)
                    fileCount++;
            }
            return fileCount;
        }
