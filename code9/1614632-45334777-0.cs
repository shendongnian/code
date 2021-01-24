    public static class UnixDateTime
    {
        private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        public static long GetUnixTimestamp(this DateTime input)
        {
            return (long)(input - UnixEpoch).TotalSeconds;
        }
    }
