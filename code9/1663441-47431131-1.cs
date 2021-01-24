    static void Main(string[] args)
    {
        byte[] file = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
        var header = file.Take(4);
        var content = file.Skip(4);
        bool isValid = IsValidHeader(header);
    }
    private static bool IsValidHeader(ReadOnlySpan<byte> header)
    {
        return header[0] == 0 && header[1] == 1;
    }
