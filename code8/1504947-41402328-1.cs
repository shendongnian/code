    public static string DecryptString(string crypted, string pass)
    {
        byte[] data = Convert.FromBase64String(crypted);
        using (RijndaelManaged rij = new RijndaelManaged())
        {
            int size = (int)(rij.BlockSize / 8);
            byte[] iv = new byte[size];
    
            // copy the iv to the array
            Array.Copy(data, 0, iv, 0, size);
    
            rij.IV = iv;
            rij.Key = HashPassword(pass);
    
            using (ICryptoTransform cryptor = rij.CreateDecryptor())
            {
                var buff = cryptor.TransformFinalBlock(data, size, data.Length - size);
                return Encoding.Unicode.GetString(buff);
            }
        }
    }
     
