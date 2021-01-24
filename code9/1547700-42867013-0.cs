        private async Task DownloadFile(DriveService service, string file_id)
        {
            
            var downloader = new MediaDownloader(service);
            downloader.ChunkSize = DownloadChunkSize;
            // add a delegate for the progress changed event for writing to console on changes
            downloader.ProgressChanged += Download_ProgressChanged;
            var fileName = DownloadDirectoryName + @"\cover_new.pdf";
            var downloadfile = service.Files.Get(file_id);
            
            Console.WriteLine("Downloading file with id: {0}", file_id);
            using (var fileStream = new System.IO.FileStream(fileName, System.IO.FileMode.Create, System.IO.FileAccess.Write))
            {
                var progress = await downloadfile.DownloadAsync(fileStream);
                
                if (progress.Status == DownloadStatus.Completed)
                {
                    Console.WriteLine(fileName + " was downloaded successfully: " + progress.BytesDownloaded);
                }
                else
                {
                    Console.WriteLine("Download {0} was interrupted in the middle. Only {1} were downloaded. ", fileName, progress.BytesDownloaded);
                }
            }
        }
