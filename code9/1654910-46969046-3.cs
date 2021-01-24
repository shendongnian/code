    var currentOrientation = UIApplication.SharedApplication.StatusBarOrientation;
    if (currentOrientation == UIInterfaceOrientation.Portrait)
    {
        videoConnection.VideoOrientation = AVCaptureVideoOrientation.Portrait;
    }
    else if (currentOrientation == UIInterfaceOrientation.LandscapeRight)
    {
        videoConnection.VideoOrientation = AVCaptureVideoOrientation.LandscapeRight;
    }
    //xxx
