    private static string ComputeNonce()
    {
        return Guid.NewGuid().ToString("N");
    }
    private static long ComputeTimestamp()
    {
        return ((long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds);
    }
