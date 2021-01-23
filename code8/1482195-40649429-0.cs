    string format = "hh:mm:ss";
    static bool ValidateTime(string time, string format)
    {
    TimeSpan times;
    return TimeSpan.TryParseExact(time,
                                        format,
                                        CultureInfo.InvariantCulture,
                                        out times);
    }
