    audioCapture = new MediaCapture();  
    var settings = new Windows.Media.Capture.MediaCaptureInitializationSettings();  
    settings.StreamingCaptureMode = Windows.Media.Capture.StreamingCaptureMode.Audio;  
    settings.MediaCategory = Windows.Media.Capture.MediaCategory.Other;  
    settings.AudioProcessing = Windows.Media.AudioProcessing.Default;  
    await audioCapture.InitializeAsync(settings);  
