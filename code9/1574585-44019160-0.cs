    private string ShaHash(string value, string signingKey)
    {
      using (var hmac = new HMACSHA1(Encoding.ASCII.GetBytes(signingKey)))
      {
        return Convert.ToBase64String(hmac.ComputeHash(Encoding.ASCII.GetBytes(value)));
      }
    }
