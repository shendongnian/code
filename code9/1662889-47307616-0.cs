    public static byte[] CarToByteArray(Car car)
    {
        BinaryFormatter binf = new BinaryFormatter();
        using (var ms = new MemoryStream())
        {
            binf.Serialize(ms, car);
            return ms.ToArray();
        }
    }
