     // Computes the Base64 encoded signature using the HMAC algorithm with the HMACSHA256 hashing function.
        string CalculateHMAC(string hmacKey, string signingstring)
    {
        byte[] key = PackH(hmacKey);
        byte[] data = Encoding.UTF8.GetBytes(signingstring);
        try
        {
            using (HMACSHA256 hmac = new HMACSHA256(key))
            {
                // Compute the hmac on input data bytes
                byte[] rawHmac = hmac.ComputeHash(data);
                // Base64-encode the hmac
                return Convert.ToBase64String(rawHmac);
            }
        }
        catch (Exception e)
        {
            throw new Exception("Failed to generate HMAC : " + e.Message);
        }
    }
    byte[] PackH(string hex)
    {
        if ((hex.Length % 2) == 1)
        {
            hex += '0';
        }
        byte[] bytes = new byte[hex.Length / 2];
        for (int i = 0; i < hex.Length; i += 2)
        {
            bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
        }
        return bytes;
    }
