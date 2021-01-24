    private static readonly string[] s_Suffixes = { "B/s", "KB/s", "MB/s" };
    public static Single ConvertTrafficValues(Double bytes, out String speedBytes)
    {
        if (bytes == 0.0d)
        {
            speedBytes = "B/s";
            return 0.0f;
        }
        Int32 magnitude = (Int32)Math.Log(bytes, 1024.0d);
        Double size;
        if (magnitude >= (s_Suffixes.Length - 1))
        {
            magnitude = s_Suffixes.Length - 1;
            size = bytes / Math.Pow(2.0d, magnitude * 10);
        }
        else
        {
            size = bytes / Math.Pow(2.0d, magnitude * 10);
            if (Math.Round(size, 2) >= 1000.0d)
            {
                magnitude += 1;
                size /= 1024.0d;
            }
        }
        speedBytes = s_Suffixes[magnitude];
        return (Single)size;
    }
