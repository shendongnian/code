     List<String> ImageFiles = Directory.GetFiles(DirPath, "*.*",
                     SearchOption.AllDirectories)
                    .Where(file => new string[] { ".jpg", ".jpeg", ".png", ".gif", ".tif" }
                    .Contains(Path.GetExtension(file)))
                    .ToList();
                    List<FileInfo> images = new List<FileInfo>();
                    foreach (string fileName in ImageFiles)
                    {
                    images.Add(new FileInfo(fileName));
                    }
