    private async void DownloadFiles(List<Uri> urls)
        {
            try
            {
                Progress<double> progress = new Progress<double>();
                foreach (Uri uri in urls)
                {
                    if (!client.isProcessCancel)
                    {
                        //Gets download progress - pgrBarDowload is our Progress Bar
                        progress.ProgressChanged += (sender, value) => pgrBarDowload.Value = (int)value;
                    }
                    var cancellationToken = new CancellationTokenSource();
                    writeOperation("Downloading File: " + uri.OriginalString);
                    
                    //Set files in download queue
                    client.isProcessCancel = false;
                    await client.DownloadFileAsync(uri.OriginalString, progress, cancellationToken.Token, directoryPath);
                }
            }
            catch (Exception ex)
            {
                writeOperation(ex.Message);
            }
    }
