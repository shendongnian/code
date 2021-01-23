    public void Stop()
    {
        lock(_frameCameralocker)
        {
            if (camera is uEye.Camera)
            {
                camera.EventFrame -= new EventHandler(NewFrameArrived);
                camera.exit;
            }
            else if (camera is DirectShowCamera)
            {
                //other stop
            }
            isRunning = false;
        }
    }
