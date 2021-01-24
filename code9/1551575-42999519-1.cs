    static DateTime lastFrame = DateTime.Now;
    private void DepthImageReady(object sender, DepthImageFrameReadyEventArgs e)
    {
        using (DepthImageFrame depthFrame = e.OpenDepthImageFrame())
        {
            if (depthFrame != null)
            {
                depthFrame.CopyDepthImagePixelDataTo(this.depthPixels);
            }
            else
            {
                // depthFrame is null because the request did not arrive in time
            }
        }
        var now = DateTime.Now;
        TimeSpan result = now.Subtract(lastFrame);
        lastFrame = now;
        var milliseconds = result.TotalMilliseconds;
        this.Text = "Kinect (" + (1000.0 / milliseconds) + "fps)";
    }
