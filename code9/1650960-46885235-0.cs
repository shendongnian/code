    string CalculateHash(string plain, string salt)
            {
                var salted = $"{plain}{{{salt}}}";
    
                var saltedBytes = Encoding.UTF8.GetBytes(salted);
    
                using (var sha512 = SHA512.Create())
                {
                    var digest = sha512.ComputeHash(saltedBytes);
    
                    var outputBytes = new byte[digest.Length + saltedBytes.Length];
    
                    for (var iteration = 1; iteration < 512; iteration++)
                    {
                        Buffer.BlockCopy(digest, 0, outputBytes, 0, digest.Length);
                        Buffer.BlockCopy(saltedBytes, 0, outputBytes, digest.Length, saltedBytes.Length);
    
                        digest = sha512.ComputeHash(outputBytes);
                    }
    
                    var result = Convert.ToBase64String(digest);
    
                    return result;
                }
