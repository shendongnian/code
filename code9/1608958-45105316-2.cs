    public static int GetSaltSize(byte[] pBytes)
    {
        var key = new Rfc2898DeriveBytes(pBytes, pBytes, 1000);
        byte[] ba = key.GetBytes(2);
        return ba.Select(x => (int)x).Sum();
    }
