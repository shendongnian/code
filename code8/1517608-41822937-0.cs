    private async void HandleDownloadAsync(DownloadOperation download, bool start)
    {
        try
        {   
            // Store the download so we can pause/resume.
            activeDownloads.Add(download);
 
            Progress<DownloadOperation> progressCallback = new Progress<DownloadOperation>(DownloadProgress);
            if (start)
            {
                 // Start the download and attach a progress handler.
                 await download.StartAsync().AsTask(cts.Token, progressCallback);
            }
            else
            {
                 // The download was already running when the application started, re-attach the progress handler.
                 await download.AttachAsync().AsTask(cts.Token, progressCallback);
            }
            ResponseInformation response = download.GetResponseInformation();
            Log(String.Format("Completed: {0}, Status Code: {1}", download.Guid, response.StatusCode));
        }
        catch (TaskCanceledException)
        {
            Log("Download cancelled.");
        }
        catch (Exception ex)
        {
            LogException("Error", ex);
        }
        finally
        {
            activeDownloads.Remove(download);
        }
    }
