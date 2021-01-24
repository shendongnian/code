    RSA LoadKeyFile(string filename)
    {
        using (System.IO.FileStream fs = System.IO.File.OpenRead(filename))
        {
            byte[] data = new byte[fs.Length];
            byte[] res = null;
            fs.Read(data, 0, data.Length);
            if (data[0] != 0x30)
            {
                res = GetPem("PRIVATE KEY", data);
            }
            try
            {
                using (CngKey key = CngKey.Import(res, CngKeyBlobFormat.Pkcs8PrivateBlob))
                {
                    return new RSACng(key);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ex :" + ex);
            }
            return null;
        }
    }
