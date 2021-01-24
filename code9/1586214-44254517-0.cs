     private static object GetFilesLineCount(string directory, string searchPattern = "*.*")
        {
            if (directory == null || !System.IO.Directory.Exists(directory))
            {
                return null;
            }
            var filesResults = System.IO.Directory.EnumerateFiles(directory, searchPattern, System.IO.SearchOption.AllDirectories)
                                            .Select(file => new
                                            {
                                                FilePath = file,
                                                TotalLines = System.IO.File.ReadLines(file).Count()
                                            }).ToList();
            return filesResults;
        }
