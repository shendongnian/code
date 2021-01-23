    public static void WriteByte<T>(T[] data, Converter<T, byte[]> converter, string path)
    {
      using (FileStream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
      {
        using (BinaryWriter writer = new BinaryWriter(stream))
        {
          foreach (var x in data)
          {
            var bytes = converter(x);
            foreach (var b in bytes)
            {
              writer.Write(b);
            }
          }
        }
      }
    }
