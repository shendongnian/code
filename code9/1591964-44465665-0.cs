    using System;
    using System.Security.Cryptography;
    using System.Text;
    
    class Program
    {
        static void Main(string[] args)
        {
            var userId = "abc12345";
            var appId = "xyz56789";
    
            Console.WriteLine($"UserId: {userId}, AppId: {appId}");
    
            byte[] IV;
            var code = QuickEncode(userId, appId, out IV);
    
            Console.WriteLine(code);
    
            var result = QuickDecode(code, IV);
    
            var uId = result.Item1;
            var aId = result.Item2;
    
            Console.WriteLine($"UserId: {uId}, AppId: {aId}");
    
            Console.ReadKey();
        }
    
        private static string QuickEncode(string userId, string appId, out byte[] IV)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
    
            var desKey = StringToByteArray("437459133faf42cb");
    
            des.Key = desKey;
            des.GenerateIV();
            IV = des.IV;
    
            ICryptoTransform encryptor = des.CreateEncryptor();
    
            var encryptMe = $"{userId}:{appId}";
    
            Console.WriteLine($"Input String: {encryptMe}");
    
            byte[] stringBytes = System.Text.Encoding.UTF8.GetBytes(encryptMe);
    
            byte[] enc = encryptor.TransformFinalBlock(stringBytes, 0, stringBytes.Length);
    
            var encryptedBytesString = Convert.ToBase64String(enc);
    
            return encryptedBytesString;
        }
    
        private static Tuple<string, string> QuickDecode(string code, byte[] IV)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
    
            var desKey = StringToByteArray("437459133faf42cb");
    
            des.Key = desKey;
            des.IV = IV;
    
            ICryptoTransform decryptor = des.CreateDecryptor();
    
            var codeBytes = Convert.FromBase64String(code);
    
            byte[] originalAgain = decryptor.TransformFinalBlock(codeBytes, 0, codeBytes.Length);
    
            var decryptMe = System.Text.Encoding.UTF8.GetString(originalAgain);
    
            Console.WriteLine($"Output String: {decryptMe}");
    
            var ids = decryptMe.Split(':');
    
            return new Tuple<string, string>(ids[0], ids[1]);
        }
    
        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }
    
        public static byte[] StringToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }
    }
