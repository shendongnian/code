    public class NewEncryptionClass()
    {
          public static string Key;
          public NewEncryptionClass()
          {
          }
          public NewEncryptionClass(string newKey)
          {
               Key = newKey; // store the key and keep it forever
          }
          static NewEncryptionClass()
          {
               Key = "key1"; // initially key is "key1"
          }
          public string Encrypt(string str)
          {
              string result = string.Empty;
              result =  "adlasdjalskd" + Key + "ajlajfalkjfa" + str; // do the Encryption, I just made up
              return result
          }
    }
