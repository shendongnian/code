    using Microsoft.AspNetCore.Cryptography.KeyDerivation;
    using Resources;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Web;
    public static class SecurityHelper
    {
         public static int DefaultIterations = 10000
    
         //KeyDerivation.Pbkdf2
         /// <summary>
         /// Generates a random salt
         /// </summary>
         /// <returns>A byte array containing a random salt</returns>
         public static byte[] GetRandomSalt()
         {
             byte[] saltBytes = new byte[32];
             RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
             rng.GetNonZeroBytes(saltBytes);            
             return saltBytes;
         }
    
         public static string GeneratePasswordHash(string plainPassword, int iterations, out string generatedRandomSalt)
         {
             generatedRandomSalt = Convert.ToBase64String(GetRandomSalt());
             return Convert.ToBase64String(ComputeHash(plainPassword, generatedRandomSalt, iterations));
         }
    
         public static string GetPasswordHash(string plainPassword, string existingSalt, int iterations)
         {
             return Convert.ToBase64String(ComputeHash(plainPassword, existingSalt, iterations));
         }
    
    
    
        private static byte[] ComputeHash(string plainText, string salt, int iterations)
        {
             return KeyDerivation.Pbkdf2(
             password: plainText,
                salt: Convert.FromBase64String(salt),
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: iterations,
                numBytesRequested: 32);
        }       
    
     }
