    // just a sample code, to get the idea
    public static string ReadString(this TextReader reader, int count)
    {
        var buffer = new char[count];
        reader.Read(buffer, 0, count);
        return string.Join(string.Empty, buffer);
    }
    public static int ReadNumeric(this TextReader reader, int count)
    {
        var str = reader.ReadString(count);
        int result;
        if (int.TryParse(str, out result))
        {
            return result;
        }
        // handle error
    }
    // ...
