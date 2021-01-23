    private static string GenerateToken(Int32 pageNumber)
    {
        byte[] currentTimeStamp = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
        var keyGuid = Guid.NewGuid();
        byte[] key = keyGuid.ToByteArray();
        byte[] newPageNumber = BitConverter.GetBytes(pageNumber);
        // date plus page number plus key
        string token = Convert.ToBase64String(currentTimeStamp.Concat(newPageNumber).Concat(key).ToArray());
        return token;
    }
