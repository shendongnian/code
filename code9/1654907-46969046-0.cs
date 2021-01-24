    var currentOrientation = UIApplication.SharedApplication.StatusBarOrientation;
    if (currentOrientation == UIInterfaceOrientation.Portrait)
    {
        stillImageOutput.VideoOrientation = AVCaptureVideoOrientation.Portrait;
    }
    else if (currentOrientation == UIInterfaceOrientation.LandscapeRight)
    {
        stillImageOutput.VideoOrientation = AVCaptureVideoOrientation.LandscapeRight;
    }
