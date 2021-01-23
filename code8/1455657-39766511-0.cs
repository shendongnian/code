    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Security.Cryptography;
    
    namespace Password
    {
        class Program
        {
            static void Main(string[] args)
            {
                string thePassword = "Hello World";
                string theHash = getHash(thePassword);
                Console.WriteLine("String: " + thePassword);
                Console.WriteLine("Encrypted Hash: " + theHash);
                Console.ReadKey(true);
            }
    
            static string getHash(string password)
            {
                // create a ripemd160 object
                RIPEMD160 r160 = RIPEMD160Managed.Create();
                // convert the string to byte
                byte[] myByte = System.Text.Encoding.ASCII.GetBytes(password);
                // compute the byte to RIPEMD160 hash
                byte[] encrypted = r160.ComputeHash(myByte);
                // create a new StringBuilder process the hash byte
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < encrypted.Length; i++)
                {
                    sb.Append(encrypted[i].ToString("X2"));
                }
                // convert the StringBuilder to String and convert it to lower case and return it.
                return sb.ToString().ToLower();
            }
        }
    }
