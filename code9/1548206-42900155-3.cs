    _camera = Android.Hardware.Camera.Open();
    
    try
    {
        _camera.SetPreviewTexture(surface);
        _camera.SetDisplayOrientation(90);
        _camera.StartPreview();
    }
    catch (Java.IO.IOException ex)
    {
        Console.WriteLine(ex.Message);
    }
