    using System;
    using System.Text;
    using System.Security.Cryptography;
    
    class Test
    {    
        private static byte[] HmacSha256(byte[] key, string data)
        {
            using (var hmac = new HMACSHA256(key))
            {
                return hmac.ComputeHash(Encoding.UTF8.GetBytes(data));
            }
        }
        
        static void Main(string[] args)
        {
            var apiSecret = "JrXRHCnUegQJAYSJ5J6OvEuOUOpy2q2-MHPoH_IECRY=";
            var stringToSign = "f3fea5f3-60af-496f-ac3e-dbb10924e87a:20160201094942:e81d298b-60dd-4f46-9ec9-1dbc72f5b5df:Qg5f0Q3ly1Cwh5M9zcw57jwHI_HPoKbjdHLurXGpPg0yazdC6OWPpwnYi22bnB6S";
            var expectedSignatur = "ps9MooGiTeTXIkPkUWbHG4rlF3wuTJuZ9qcMe-Y41xE=";
            
            apiSecret = apiSecret.Replace('-', '+').Replace('_', '/').PadRight(apiSecret.Length + (4 - apiSecret.Length % 4) % 4, '=');
            
            var secretBase64Decoded = Convert.FromBase64String(apiSecret);
            
            var hmac = Convert.ToBase64String(HmacSha256(secretBase64Decoded, stringToSign));
            
            var signatur = hmac.Replace('+', '-').Replace('/', '_');
            Console.WriteLine($"signatur: {signatur}");
            Console.WriteLine($"expected: {expectedSignatur}");            
            Console.WriteLine(signatur.Equals(expectedSignatur));
        }
    }
