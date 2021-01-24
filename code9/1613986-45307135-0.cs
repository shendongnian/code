    public static string DecimalToBase64(List<int> lst)
    {
        var bytes = new List<byte>();
        foreach (var item in lst)
            bytes.AddRange(BitConverter.GetBytes(item));
        return Convert.ToBase64String(bytes.ToArray());
    }
