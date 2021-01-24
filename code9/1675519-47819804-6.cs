    static void Main(string[] args)
    {
        var ffMpeg = new FFMpegConverter();
        ffMpeg.ConvertProgress += FfMpeg_ConvertProgress;
        ffMpeg.ConvertMedia("input.mov", "output.mp4", Format.mp4);
    }
    private static void FfMpeg_ConvertProgress(object sender, ConvertProgressEventArgs e)
    {
        // Percent complete as a double
        pgbConversion.Value = e.Processed.TotalSeconds / e.TotalDuration.TotalSeconds;
    }
