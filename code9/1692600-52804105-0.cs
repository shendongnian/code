    DispatcherTimer Timer = new DispatcherTimer();  
    Timer.Tick += Timer_Tick;  
    Timer.Interval = TimeSpan.FromMilliseconds(30);  
    Timer.Start();
    private void Timer_Tick(object sender, EventArgs e)
    {
        if (videoCapture.Read(frame))
        {
            view.Source = OpenCvSharp.Extensions.BitmapSourceConverter.ToBitmapSource(frame);
        }
    }
