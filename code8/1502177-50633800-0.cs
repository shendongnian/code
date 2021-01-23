    //Rextester.Program.Main is the entry point for your code. Don't change it.
    //Compiler version 4.0.30319.17929 for Microsoft (R) .NET Framework 4.5
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Security.Cryptography;
    using System.Text;
    
    namespace Rextester
    {
        public static class RabbitMqPasswordHelper
    {
        public static string EncodePassword(string password)
        {
            using (RandomNumberGenerator rand = RandomNumberGenerator.Create())
            using (var sha256 = SHA256.Create())
            {
                byte[] salt = new byte[4];
    
                rand.GetBytes(salt);
    
                byte[] saltedPassword = MergeByteArray(salt, Encoding.UTF8.GetBytes(password));
                byte[] saltedPasswordHash = sha256.ComputeHash(saltedPassword);
    
                return Convert.ToBase64String(MergeByteArray(salt, saltedPasswordHash));
            }
        }
    
        private static byte[] MergeByteArray(byte[] array1, byte[] array2)
        {
            byte[] merge = new byte[array1.Length + array2.Length];
            array1.CopyTo(merge, 0);
            array2.CopyTo(merge, array1.Length);
    
            return merge;
        }
    }
        
        public class Program
        {
            public static void Main(string[] args)
            {
                //Your code goes here
                Console.WriteLine(Rextester.RabbitMqPasswordHelper.EncodePassword("MyPassword"));
            }
        }
    }
