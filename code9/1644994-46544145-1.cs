    public void DownloadFileAndSave(Models.DocumentModel document)
    {
      WebClient webClient = new WebClient();
      webClient.Headers.Add(HttpRequestHeader.Authorization, "Basic " + WebApiUtils.GetEncodedCredentials(Auth.Users.Current));
      string tempPath = Path.GetTempPath();
      string localFilename = Path.GetFileName(document.FileName);
      string localPath = Path.Combine(tempPath, localFilename);
      webClient.DownloadFileCompleted += (sender, e) =>
      {
        Device.BeginInvokeOnMainThread(() =>
        {
          QLPreviewItemFileSystem prevItem = new QLPreviewItemFileSystem(localFilename, localPath); // ql = quick look
          QLPreviewController previewController = new QLPreviewController()
          {
            DataSource = new PreviewControllerDS(prevItem)
          };
          UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(previewController, true, null);
        });
      };
      // download file
      Uri uri = new System.Uri(WebApiUtils.GetBaseUrl() + string.Format(Consts.ApiUrls.GetDocument, document.UniqueId));
      webClient.DownloadFileAsync(uri, localPath);
    }
