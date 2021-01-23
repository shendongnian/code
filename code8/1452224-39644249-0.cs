    {
        // 3. Create a HMAC from a stream than add a byte to the result and create a second HMAC
        byte[] keyHmac = new byte[] {255};
        var hmac = new HMACSHA512(keyHmac);
        using (var resultStream = new MemoryStream()) {
           using (var hmacStream = new CryptoStream(resultStream, hmac, CryptoStreamMode.Write)) {
               new MemoryStream(new byte[] {1, 2, 3}).CopyTo(hmacStream);
            }
        }
        var result = hmac.Hash;
        hmac = new HMACSHA512(keyHmac);
        result = hmac.ComputeHash(result.Concat(new byte[] {7}).ToArray());
        Console.Out.WriteLine($"{Convert.ToBase64String(result)}");
    }
