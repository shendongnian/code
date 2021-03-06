    static void Main(string[] args)
    {
        var ffMpeg = new FFMpegConverter();
        ffMpeg.ConvertProgress += (s, e) => {
            pgbConversion.Value = e.Processed.TotalSeconds / e.TotalDuration.TotalSeconds;
        };
        ffMpeg.ConvertMedia("input.mov", "output.mp4", Format.mp4);
    }
