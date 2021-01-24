    private static byte[] ToByteArray(string input)
    {
        return Encoding.Unicode.GetBytes(input);
    }
    private static string ToString(byte[] input)
    {
        return Encoding.Unicode.GetString(input);
    }
