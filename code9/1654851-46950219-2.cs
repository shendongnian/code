        public void GetFileCount(string sPath, FolderItem actualFolder)
        {
            if (Directory.Exists(sPath))
            {
                foreach (string fileName in Directory.GetFiles(sPath))
                {
                    FileItem newFile = new FileItem();
                    newFile.Info = new FileInfo(fileName);
                    actualFolder.Elems.Add(newFile);
                }
                foreach (string subFolder in Directory.GetDirectories(sPath))
                {
                    FolderItem newSubFolder = new FolderItem();
                    newSubFolder.Info = new DirectoryInfo(subFolder);
                    actualFolder.Elems.Add(newSubFolder);
                    GetFileCount(subFolder, newSubFolder);
                }
            }
        }
