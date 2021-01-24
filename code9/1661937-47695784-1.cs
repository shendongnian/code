    public void OnSurfaceTextureUpdated(SurfaceTexture surface)
        {
        var display = activity.WindowManager.DefaultDisplay;
        if (display.Rotation == SurfaceOrientation.Rotation0)
        {
            _camera.SetDisplayOrientation(90);
        }
        if (display.Rotation == SurfaceOrientation.Rotation90)
        {
            _camera.SetDisplayOrientation(0);
        }
        if (display.Rotation == SurfaceOrientation.Rotation180)
        {
            _camera.SetDisplayOrientation(180);
        }
        if (display.Rotation == SurfaceOrientation.Rotation270)
        {
            _camera.SetDisplayOrientation(180);
        }
    }
