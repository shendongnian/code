    static void Main(string[] args)
    {
        byte[] file = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
        byte[] header = file.Take(4).ToArray();
        byte[] content = file.Skip(4).ToArray();
        bool isValid = IsValidHeader(header);
    }
    private static bool IsValidHeader(byte[] header)
    {
        return header[0] == 0 && header[1] == 1;
    }
