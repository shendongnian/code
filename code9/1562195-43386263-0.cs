    byte[] bytes = null;
    BinaryFormatter bf = new BinaryFormatter();
    using (MemoryStream ms = new MemoryStream())
    {
        bf.Serialize(ms, categoryList);
        bytes = ms.ToArray();
    }
