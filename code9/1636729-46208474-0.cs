    public void OpenPdf(string localPath, string localFilename)
                {
                    WebClient webClient = new WebClient();
                    webClient.DownloadFileCompleted += (sender, args) =>
                    {
                        Device.BeginInvokeOnMainThread(delegate
                        {
                            userDialogService.HideLoading();
        
                            QLPreviewItemFileSystem prevItem = new QLPreviewItemFileSystem(localFilename, localPath);
                            QLPreviewController previewController = new QLPreviewController();
                            previewController.DataSource = new PreviewControllerDS(prevItem);
                            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(previewController, true, null);
                        });
                    };
                    webClient.DownloadFileAsync(uri, localPath);
        }
