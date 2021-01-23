    private void webcam_newFrame(object sender, NewFrameEventArgs eventArgs) {
      if (!_pause) {
          Bitmap oldBitmap = (Bitmap)pbPicture.BackgroundImage;
          pbPicture.BackgroundImage = (Bitmap)eventArgs.Frame.Clone();
          oldBitmap.Dispose();
      }
    }
  
