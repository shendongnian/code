    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;
    namespace ConsoleApplication3
    {
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a four digit Number");
            var number = Console.ReadLine();
            if (!(number.Length == 4))
            {
                Console.WriteLine("Enter a four digit Number");
            }
            int i = int.Parse(number);
            var bytearr = BitConverter.GetBytes(i);
           method(bytearr);
            Console.ReadLine();
            
        }
        public static void method(byte[] secret)
        {
            byte[] encryptedSecret = DataProtectionSample.Protect(secret);
            Console.WriteLine("The encrypted byte array is:");
            DataProtectionSample.PrintValues(encryptedSecret);
            // Decrypt the data and store in a byte array.
            byte[] originalData =          DataProtectionSample.Unprotect(encryptedSecret);
            Console.WriteLine("{0}The original data is:", Environment.NewLine);
            DataProtectionSample.PrintValues(originalData);
            Console.WriteLine(BitConverter.ToInt32(originalData, 0));
        }
    }
    }
