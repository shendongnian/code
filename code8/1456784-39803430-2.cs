    using System.Security.Cryptography;
    using System.Text;
    //--------------------MyHmac.cs-------------------
    public static class MyHmac
    {
        private const int SaltSize = 32;
        public static byte[] GenerateSalt()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var randomNumber = new byte[SaltSize];
                rng.GetBytes(randomNumber);
                return randomNumber;
            }
        }
        public static byte[] ComputeHMAC_SHA256(byte[] data, byte[] salt)
        {
            using (var hmac = new HMACSHA256(salt))
            {
                return hmac.ComputeHash(data);
            }
        }
    }
    //-------------------Program.cs---------------------------
    string orgMsg = "Original Message";
            string otherMsg = "Other Message";
            Console.WriteLine("HMAC SHA256 Demo in .NET");
            Console.WriteLine("----------------------");
            Console.WriteLine();
            var salt = MyHmac.GenerateSalt();
            var hmac1 = MyHmac.ComputeHMAC_SHA256(Encoding.UTF8.GetBytes(orgMsg), salt);
            var hmac2 = MyHmac.ComputeHMAC_SHA256(Encoding.UTF8.GetBytes(otherMsg), salt);
            Console.WriteLine("Original Message Hash:{0}", Convert.ToBase64String(hmac1));
            Console.WriteLine("Other Message Hash:{0}", Convert.ToBase64String(hmac2));
