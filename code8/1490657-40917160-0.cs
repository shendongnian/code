    public class Encryption {
         private readonly Regex regex = new Regex("[A-Za-z0-9]+");
         public string Encrypt(string toEncrypt)
              if (toEncrypt == null)
                 throw new ArgumentNullException("toEncrypt");
              if (!regex.IsMatch(toEncrypt))
                 throw new ArgumentException("String is not alphanumeric");
              // Obviously pseudocode 
              return EncryptionAlgorithm.Encrypt(toEncrypt, whateverKey);
         }
    }
