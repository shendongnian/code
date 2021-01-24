    using System;
    using System.IO;
    namespace email_zip
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                 byte[] bytes = File.ReadAllBytes("./7738292858_January_February_2017.zip");
                 string base64 = System.Convert.ToBase64String(bytes);
                 Console.WriteLine(base64);
            }
        }
    }
