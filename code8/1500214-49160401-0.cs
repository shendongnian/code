    string sha256_hash(string value) {
        StringBuilder stringBuilder = new StringBuilder();
        using (SHA256 hash = SHA256.Create()) {
            Encoding enc = Encoding.UTF8;
            Byte[] resultingHash = hash.ComputeHash(enc.GetBytes(value));
            foreach (Byte b in resultingHash) {
                stringBuilder.Append(b.ToString("x2"));
            }
        }
        return stringBuilder.ToString();
    }
    // First compute SHA256 hash
    string sha256hash = sha256_hash("my_password");
    // Let BCrypt.Net rehash and check if it matches Meteor's hash
    if (BCrypt.Net.BCrypt.Verify(sha256hash, dbPassword) == true) {
        Console.WriteLine("Valid!");
    }
