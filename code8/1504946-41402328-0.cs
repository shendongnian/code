    public class EncryptClass
    {
        const int hashCount = 21569;
               
        public static string EncryptString(string message, string pass)
        {
            using (RijndaelManaged rij = new RijndaelManaged())
            {
                rij.GenerateIV();
                rij.Key = HashPassword(pass);
    
                using (ICryptoTransform cryptor = rij.CreateEncryptor())
                {
                    var data = Encoding.Unicode.GetBytes(message);
                    var buff = cryptor.TransformFinalBlock(data, 0, data.Length);
                    // concat to the IV for the other side
                    // crypto data is binary - use Base64 for text encoding
                    return Convert.ToBase64String(rij.IV.Concat(buff).ToArray());
                }
            }
        }
    
        private static byte[] HashPassword(string thePW)
        {
            // originally from RNGCryptoServiceProvider.GetRandomBytes
            byte[] salt = new byte[] { 96, 248, 204, 72, 177, 214, 251, 82, 174, 
                            90, 82, 90, 111, 76, 146, 172 };
    
            using (var hasher = new Rfc2898DeriveBytes(thePW, salt, hashCount))
            {
                return hasher.GetBytes(32);
            }
        }
