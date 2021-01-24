     public static string CreateKey()
            {
                var alg = Aes.Create();
                alg.KeySize = 256;
                return Convert.ToBase64String(inArray: alg.Key);
            }
     public string EncryptAes(string inputText)
            {
                if (inputText == null) return null;
                var hashing = new Hashing(text: inputText);
                var hash = hashing.GetHash();
                var inputBytes = Encoding.UTF8.GetBytes(s: inputText);
                using (var ms = new MemoryStream())
                {
                    var alg = Aes.Create();
                    var pdb = new Rfc2898DeriveBytes(password: _key, salt: alg.IV);
                    alg.Key = pdb.GetBytes(32);
                    alg.IV = pdb.GetBytes(16);
                    using (
                        var cs = new CryptoStream(stream: ms, transform: alg.CreateEncryptor(),
                            mode: CryptoStreamMode.Write)
                    )
                    {
                        cs.Write(buffer: inputBytes, offset: 0, count: inputBytes.Length);
                    }
                    return hash + Convert.ToBase64String(inArray: pdb.Salt) + Convert.ToBase64String(inArray: ms.ToArray());
                }
            }
    
            public string DecryptAes(string inputText)
            {
                if (inputText == null) return null;
                var inputBytes = Convert.FromBase64String(s: inputText.Substring(52));
                var pdb = new Rfc2898DeriveBytes(password: _key,
                    salt: Convert.FromBase64String(s: inputText.Substring(28, 24)));
    
                using (var ms = new MemoryStream())
                {
                    var alg = Aes.Create();
                    alg.Key = pdb.GetBytes(32);
                    alg.IV = pdb.GetBytes(16);
    
                    using (
                        var cs = new CryptoStream(stream: ms, transform: alg.CreateDecryptor(), mode: CryptoStreamMode.Write)
                    )
                    {
                        cs.Write(buffer: inputBytes, offset: 0, count: inputBytes.Length);
                    }
                    return Encoding.UTF8.GetString(bytes: ms.ToArray());
                }
            }
