    static byte[] ReadFully(Stream input, int size)
    {
        byte[] buffer = new byte[size];
        using (MemoryStream ms = new MemoryStream())
        {
            int read;
            while ((read = input.Read(buffer, 0, size)) > 0)
            {
                ms.Write(buffer, 0, read);
            }
            return ms.ToArray();
        }
    }
