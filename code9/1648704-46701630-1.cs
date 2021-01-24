    device = AVCaptureDevice.GetDefaultDevice(AVMediaTypes.Video);
    input = AVCaptureDeviceInput.FromDevice(device, out var error);
    if (error == null)
    {
        session = new AVCaptureSession();
        session.AddInput(input);
        session.SessionPreset = AVCaptureSession.PresetPhoto;
        var previewLayer = AVCaptureVideoPreviewLayer.FromSession(session);
        previewLayer.Frame = playerView.Bounds;
        Control.Layer = previewLayer;
        output = new AVCaptureStillImageOutput();
        session.AddOutput(output);
        session.StartRunning();
        connection = output.ConnectionFromMediaType(AVMediaType.Video);
    }
