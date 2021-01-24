      class Program
      {
        static void Main(string[] args)
        {
          Console.WriteLine("AES Test Program\n\n");
    
          string passPhrase = "MyPassword";
          string secretText = "This is my secret text";
    
          var encrypted = Encrypt(passPhrase, new CryptData(secretText));
    
          Console.WriteLine("Encrypted: " + encrypted.Base64Text);
    
          var decrypted = Decrypt(passPhrase, encrypted);
    
          Console.WriteLine("Decrypted: " + decrypted.Text);
    
          Console.WriteLine("\nPress <ENTER> to exit");
          Console.ReadLine();
        }
    
        private static CryptData Encrypt(string passPhrase, CryptData plainData)
        {
          using (var enc = new SymmetricEncryptionHelper(passPhrase))
          {
            return enc.Encrypt(plainData);
          }
        }
    
        private static CryptData Decrypt(string passPhrase, CryptData encryptedData)
        {
          using (var dec = new SymmetricEncryptionHelper(passPhrase))
          {
            return dec.Decrypt(encryptedData);
          }
        }
      }
