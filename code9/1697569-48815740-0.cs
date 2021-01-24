      using(var hmac = new HMACSHA512(Encoding.UTF8.GetBytes(apiSecret)))
      {
        byte[] signHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(parameters));
        string sign = BitConverter.ToString(signHash).ToLower().Replace("-", string.Empty);
        request.Content.Headers.Add("Sign", sign);
      }
