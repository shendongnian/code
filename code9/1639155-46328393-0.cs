        private void documentBackup(string docSavePath)
        {
            if (File.Exists(docSavePath + @"\Documents.zip")) File.Delete(docSavePath + @"\Documents.zip");
            using (ZipArchive docZip = ZipFile.Open(docSavePath + "\\Documents.zip", ZipArchiveMode.Create))
            {
                foreach (FileInfo goodFile in RecurseDirectory(documentsFolder))
                {
                        var destination = Path.Combine(goodFile.DirectoryName, goodFile.Name).Substring(documentsFolder.ToString().Length + 1);
                        docZip.CreateEntryFromFile(Path.Combine(goodFile.Directory.ToString(), goodFile.Name), destination);                    
                }
            }
        }
        public IEnumerable<FileInfo> RecurseDirectory(string path, List<FileInfo> currentData = null)
        {
            if (currentData == null)
                currentData = new List<FileInfo>();
            var directory = new DirectoryInfo(path);
                    foreach (var file in directory.GetFiles())
                        currentData.Add(file);
            foreach (var d in directory.GetDirectories())
            {
                if ((d.Attributes & FileAttributes.ReparsePoint) == FileAttributes.ReparsePoint)
                {
                    continue;
                }
                else
                {
                    RecurseDirectory(d.FullName, currentData);
                }
            }
            return currentData;
        }
