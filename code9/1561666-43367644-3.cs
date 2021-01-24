    async static Task<byte[]> Encrypt(string privateKey, string pin, byte[] data)
    {
        using (var sha = SHA256.Create())
        {
            byte[] keyHash = sha.ComputeHash(Encoding.UTF8.GetBytes($"{privateKey}"));
            byte[] pinHash = sha.ComputeHash(Encoding.UTF8.GetBytes($"{pin}"));
            using (Aes aes = Aes.Create())
            {
                byte[] key = keyHash.Slice(0, aes.Key.Length);
                byte[] iv = pinHash.Slice(0, aes.IV.Length);
                Trace.WriteLine($"Key length: { key.Length }, iv length: { iv.Length }, block mode: { aes.Mode }, padding: { aes.Padding }");
                using (var stream = new MemoryStream())
                using (ICryptoTransform transform = aes.CreateEncryptor(key, iv))
                {
                    using (var cryptStream = new CryptoStream(stream, transform, CryptoStreamMode.Write))
                    {
                        await cryptStream.WriteAsync(data, 0, data.Length);
                    }
                    return stream.ToArray();
                }
            }
        }
    }
