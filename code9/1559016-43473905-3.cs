    public String GenerateToken(Guid id, params object[] allData)
    {
        byte[] idBin = id.ToByteArray();
        byte[] total = new byte[] { };
        total.Concat(idBin);
        foreach (var data in allData)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, data);
                total.Concat(ms.ToArray());
            }
        }
        String token = Convert.ToBase64String(total);
        return token;
    }
