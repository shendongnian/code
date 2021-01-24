    byte[] salt = new byte[128 / 8];
    string hashedPassword;
    using (var hmac = new HMACSHA512()) {
         hashedPassword = Convert.ToBase64String(new Pbkdf2(
             hmac, "GN(o@D30", Encoding.UTF8.GetString(salt), 100000).GetBytes(256 / 8));                
    }
