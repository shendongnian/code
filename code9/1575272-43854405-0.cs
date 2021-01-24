    private static readonly DateTime UnixEpoch =
        new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
    // TODO: Give this a clearer name
    public static int GetUnixTimestamp(int days)
        => (int) ((DateTime.UtcNow.Date.AddDays(-days) - UnixEpoch).TotalSeconds);
