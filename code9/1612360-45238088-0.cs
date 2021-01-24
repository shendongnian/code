    private WasapiCapture capture;
    private WaveWriter writer;
    private Timer silenceTimer;
    public Constructor()
    {
        silenceTimer = new Timer();
        silenceTimer.Interval = 5000; // 5 seconds
        silenceTimer.Elapsed +=SilenceTimerElapsed;
    }
    private void SilenceTimerElapsed(object sender, ElapsedEventArgs e)
    {
        silenceTimer.Stop();
     	stopRecording();
    }
    private void startRecording()
    {
        capture = new WasapiCapture();
        capture.Initialize();
        writer = new WaveWriter("file.wav", capture.WaveFormat);
        capture.DataAvailable += (s, capData) =>
        {
            writer.Write(capData.Data, capData.Offset, capData.ByteCount);
            silenceTimer.Stop();
            silenceTimer.Start(); // Resetting timer
        };
        silenceTimer.Start();
        capture.Start();
    }
    private void stopRecording()
    {
        if (writer != null && capture != null)
        {
            capture.Stop();
            writer.Dispose();
            capture.Dispose();
        }
    }
