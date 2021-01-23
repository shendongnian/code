    public static Stream FromBase64(this string content)
    {
        var bytes = Convert.FromBase64String(content);
        var stream = new MemoryStream();
        stream.Write(bytes, 0, bytes.Length);
        stream.Seek(0, SeekOrigin.Begin); // here
        return stream;
    }
