    const int KeySize = 128;
    static string HashTheKey(string key) {
      String hashKey;
      using (var sha = new SHA1Managed()) {
       hashKey = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(key)));
      }
      // beware - you're on C# now so remove the padding and add the newline to match java
      return hashKey.Replace("=", "") + "\n";
    }
    static byte[] GetSecretKey(string password) {
      var salt = Encoding.UTF8.GetBytes("JVAaVhAiddKAaghraikhmaini");
      using (var pass = new Rfc2898DeriveBytes(password, salt, 65536)) {
        return pass.GetBytes(KeySize / 8);
      }
    }
    static void Main(string[] args) {
      string encrypted = "vtlkQHTz7/oz2weuAAkLz2Q5c2yj2LGukF7SHJjT+TA8oRLixTQSXQ7dG1O736hyT1HJxcz0P4DzzVaO5chWKKSJQ2uPEpDQJu/fZGguqDw=";
      byte[] encryptedBytes = Convert.FromBase64String(encrypted);
      using (var aes = new AesManaged()) {
        aes.KeySize = KeySize;
        aes.Padding = PaddingMode.PKCS7;
        aes.Key = GetSecretKey(HashTheKey("Android"));
        // you're using the same init vector in your android code
        aes.IV = new byte[16];
        using (var decryptor = aes.CreateDecryptor()) {
          // dumps {"barcode":"12345678","token":"cad603fc-1e53-4a95-9150-f1694baa07f9"}
          Console.Out.WriteLine(Encoding.UTF8.GetString(decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length)));
        }
      }
    }
