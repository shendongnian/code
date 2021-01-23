    private Bitmap _imageToProcess = null;
    private bool _processingImage = false;
    private void NewVideoFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
    {
        _imageToProcess = (Bitmap)eventArgs.Frame.Clone();
        LiveView = (Bitmap)eventArgs.Frame.Clone();
    }
    private void StartProcessImage()
    {
        Thread t = new Thread(ProcessImage);
        t.Start();
        _processingImage = true;
    }
    private void ProcessImage()
    {
        while(_processingImage)
        {
            SomeLiveVideoFaceDetectFunction((Bitmap)_imageToProcess.Clone()); 
            OrSomeShapeDetectionFunction((Bitmap)_imageToProcess.Clone());
        }
        _processingImage = false;
    }
