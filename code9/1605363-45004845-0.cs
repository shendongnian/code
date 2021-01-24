    private async Task StartPreviewAsync()
     {
         try
         {
             _mediaCapture = new MediaCapture();
             await _mediaCapture.InitializeAsync();
             _displayRequest.RequestActive();
             DisplayInformation.AutoRotationPreferences = DisplayOrientations.Landscape;
         }
         catch (UnauthorizedAccessException)
         {
    
         }
         try
         {
             PreviewControl.Source = _mediaCapture;
             await _mediaCapture.StartPreviewAsync();
             _isPreviewing = true;
         }
         catch (System.IO.FileLoadException)
         {
    
         }
     }
