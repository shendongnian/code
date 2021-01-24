    //setup face detection
    var definition = new FaceDetectionEffectDefinition();
    definition.SynchronousDetectionEnabled = false;
    definition.DetectionMode = FaceDetectionMode.HighPerformance;
    faceDetection = (FaceDetectionEffect)await mediaCapture.AddVideoEffectAsync(definition, MediaStreamType.Photo);
    faceDetection.DesiredDetectionInterval = TimeSpan.FromMilliseconds(33);
    faceDetection.FaceDetected += FaceDetection_FaceDetected;
    faceDetection.Enabled = true;
    ...
    private async void FaceDetection_FaceDetected(FaceDetectionEffect sender, FaceDetectedEventArgs args) {
                
        if(args.ResultFrame.DetectedFaces.Count() > 0) {
            Debug.WriteLine(string.Format("Detected {0} faces", args.ResultFrame.DetectedFaces.Count()));
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => HighlightDetectedFaces(args.ResultFrame.DetectedFaces));
            if (!countdownStarted)
                await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => startCountdown());
        }
    }
