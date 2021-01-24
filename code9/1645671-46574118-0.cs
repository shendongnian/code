    public static string CalculateSignature(string text, string secretKey)
    {
        using (var hmacsha512 = new HMACSHA512(Encoding.UTF8.GetBytes(secretKey)))
        {
            byte[] hmac = hmacsha512.ComputeHash(Encoding.UTF8.GetBytes(text));
            StringBuilder builder = new StringBuilder(hmac.Length * 2);
            foreach (byte b in hmac)
            {
                builder.Append(b.ToString("x2"));
            }
            return builder.ToString();
        }
    }
