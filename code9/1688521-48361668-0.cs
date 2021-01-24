    /// <summary>
    /// Stops all ffmpeg processes on the local machine
    /// </summary>
    private void StopCapturing()
    {
        Process process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "taskkill",
                Arguments = "/F /IM ffmpeg.exe",
                UseShellExecute = false,
                CreateNoWindow = true
            }
        };
        process.Start();
    }
