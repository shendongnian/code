    DateTimeOffset date = new DateTimeOffset(2017, 6, 20, 22, 09, 0, 0, TimeSpan.FromHours(-4));
    // 20 June 2017, 22:09, GMT-4
    public static DateTimeOffset ParseIso8601(string iso8601String)
    {
        return DateTimeOffset.ParseExact(
            iso8601String,
            new string[] { "yyyy-MM-dd'T'HH:mm:ss.FFFK" },
            CultureInfo.InvariantCulture,
            DateTimeStyles.None);
    }
