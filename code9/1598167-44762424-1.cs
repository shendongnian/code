     public string GetHash()
            {
                using (var sha1 = SHA1.Create())
                {
                    var hashedBytes = sha1.ComputeHash(buffer: Encoding.UTF8.GetBytes(s: _text));
                    return Convert.ToBase64String(inArray: hashedBytes).Replace(oldValue: "-", newValue: "");
                }
            }
    
            public string GetHashFromEncryption(string text)
            {
                return text.Substring(0,28);
            } 
