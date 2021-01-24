            var blob_Archive = Environment.GetEnvironmentVariable("blobName", EnvironmentVariableTarget.Process);
            var archiveSheetFile = $"{blob_Archive}/FileName-{DateTime.UtcNow:ddMMyyyy_hh.mm}.csv";
            using (var txReader = await binder.BindAsync<TextReader>(
            new BlobAttribute(file2read, FileAccess.Read)))
            {
                if(txReader != null)
                sBlobNotification = await txReader.ReadToEndAsync();
            }
            log.LogInformation($"{sBlobNotification}");
