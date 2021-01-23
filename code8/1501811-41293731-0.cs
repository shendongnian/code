    private void webcam_newFrame(object sender, NewFrameEventArgs eventArgs) {
        if (!_pause) {
            var img = (Bitmap) eventArgs.Frame.Clone();
            var oldImg =  pbPicture.BackgroundImage;
            pbPicture.BackgroundImage = img;
            oldImg?.Dispose();
        }
    }
