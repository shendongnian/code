    byte[] result;
    using (MemoryStream ms = new MemoryStream())
    {
        using (CryptoStream cs = new CryptoStream(ms, transform, CryptoStreamMode.Write))
        {
            cs.Write(inputData, 0, inputData.Length);
        }
        result = ms.ToArray();
    }
