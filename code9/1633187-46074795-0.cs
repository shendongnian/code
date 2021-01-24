    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string hexBytes = "48 65 6C 6C 6F 20 77 6F 72 6c 64 21 00 00 00 00";
                byte[] bytes = hexBytes.Split(' ').Select(hex => byte.Parse(hex, NumberStyles.HexNumber)).ToArray();
                string text = Encoding.ASCII.GetString(bytes);
                Console.WriteLine(text);
            }
        }
    }
