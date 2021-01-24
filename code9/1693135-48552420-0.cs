    double FilesCount = 0;
    double CopyCount = 0;
        public async void CreateSample(string outPathname, string folderName)
        {
            FileStream fsOut = File.Create(outPathname);
            ZipOutputStream zipStream = new ZipOutputStream(fsOut);
            zipStream.SetLevel(3);
            zipStream.Password = null;
            int folderOffset = folderName.Length + (folderName.EndsWith("\\") ? 0 : 1);
            CreateBackupProgress.IsVisible = true;
            
            Task task1 = new Task(CheckProgressbar);
            task1.Start();
            Task task2 = new Task(() => CompressFolderAsync(folderName, zipStream, folderOffset));
            task2.Start();
            await task1;
            await task2;
            zipStream.IsStreamOwner = true;
            zipStream.Close();
            await DisplayAlert("Creating Backup", "Creating backup is completed successfully. The buckup file is store in the following path: " + outPathname, "Ok");
        }
        private void CompressFolderAsync(string path, ZipOutputStream zipStream, int folderOffset)
        {
            string[] files = Directory.GetFiles(path);
            foreach (string filename in files)
            {
                FileInfo fi = new FileInfo(filename);
                string entryName = filename.Substring(folderOffset);
                entryName = ZipEntry.CleanName(entryName);
                ZipEntry newEntry = new ZipEntry(entryName);
                newEntry.DateTime = fi.LastWriteTime;
                newEntry.Size = fi.Length;
                zipStream.PutNextEntry(newEntry);
                byte[] buffer = new byte[4096];
                using (FileStream streamReader = File.OpenRead(filename))
                {
                    StreamUtils.Copy(streamReader, zipStream, buffer);
                }
                zipStream.CloseEntry();
            }
            CopyCount += 1;
            string[] folders = Directory.GetDirectories(path);
            foreach (string folder in folders)
            {
                CompressFolderAsync(folder, zipStream, folderOffset);
            }
        }
       
        private async void CheckProgressbar()
        {
            
            while (CopyCount != FilesCount)
            {
                await Task.Run(() => { Thread.Sleep(100); }); 
                await CreateBackupProgress.ProgressTo(CopyCount / FilesCount, 100, Easing.Linear);
                
            }
            await CreateBackupProgress.ProgressTo(1, 100, Easing.Linear);
            
        }
