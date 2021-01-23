    private void CaptureCameraCallback()
    {
        frame = new Mat();
        capture = new VideoCapture();
        capture.Open(2);
        while (isCameraRunning == 1)
        {
            capture.Read(frame);
            image = BitmapConverter.ToBitmap(frame);
            pictureBox1.Image = image;
            image = null;
        }
    }
