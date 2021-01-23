    public static void WriteBytes<T>(T[] data, Converter<T, byte[]> converter, string path)
    {
      using (FileStream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
      {
        foreach (T x in data)
        {
          var buffer = converter(x);
          stream.Write(buffer, 0, buffer.Length);
        }
      }
    }
