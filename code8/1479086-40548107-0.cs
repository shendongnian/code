    public static class MyDateTime
    {
        public static string ToS(DateTime dt)
        {
            return dt.ToString("d/M/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
        }
    }
