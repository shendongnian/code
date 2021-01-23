    private async void InitCapture()
       // Initialize everything about MediaCapture.
       {
       this.captureMgr = new MediaCapture();
       await this.captureMgr.InitializeAsync();
       // Skip the steps to set the photo resolution to simplify
       // the sample program.
       // Start the camera preview.
       captureElement.Source = this.captureMgr;
       await this.captureMgr.StartPreviewAsync();
       // Ask the camera to auto-focus now.
       var focusControl = this.captureMgr.VideoDeviceController.FocusControl;
       var settings = new FocusSettings { Mode           = FocusMode.Continuous,
                                          AutoFocusRange = AutoFocusRange.FullRange };
       focusControl.Configure( settings );
       await focusControl.FocusAsync();       // Wait for the camera to focus
       // Turn on the torch in case the lighting is dim. Without enough
       // lighting, the auto-focus feature of the camera cannot work.
       var cameraTorch = this.captureMgr.VideoDeviceController.TorchControl;
       if ( cameraTorch.Supported )
          {
          if ( cameraTorch.PowerSupported )
             cameraTorch.PowerPercent = 100;
          cameraTorch.Enabled = true;
          }
       #region Error handling
       MediaCaptureFailedEventHandler handler = (sender, e) =>
          {
           System.Threading.Tasks.Task task = System.Threading.Tasks.Task.Run(async () =>
             {
             await new MessageDialog( "There was an error capturing the video from camera.", "Error" ).ShowAsync();
             });
          };
       
       this.captureMgr.Failed += handler;
       #endregion
       }
