    using System;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                const string inputString = "43 50 43 52 00 01 19 00 00 00 34 01 00 00 1B 01 00 00 0B 01 0B 01 3C 00 00 32 00 01 FF FF 0C 00 48 56 41 43 20 43 54 52 4C 00 02 02 40 01 46 0B 01 00 00 00 00 00 00 45 4D 2D 4D 38 38 49 23 31 00 11 00 00 00 00 81 01 00 00 00 00 00 00 41 43 31 4D 38 38 49 23 32 00 11 00 00 00 00 81 02 00 00 00 00 00 00 45 4D 2D 4D 38 38 4F 23 31 00 12 00 00 00 00 82 01 00 00 00 00 00 00 41 43 31 4D 38 38 4F 23 32 00 12 00 00 00 00 82 02 00 00 00 00 00 00 41 43 32 4D 52 54 55 23 31 00 0F 03 0B 01 46 90 01 00 00 00 00 00 00 41 43 33 4D 52 54 55 23 32 00 0F 03 0B 01 46 90 02 00 00 00 00 00 00 41 43 34 4D 52 54 55 23 33 00 0F 03 0B 01 46 90 03 00 00 00 00 00 00 41 43 35 4D 52 54 55 23 34 00 0F 03 0B 01 46 90 04 00 00 00 00 00 00 41 43 36 4D 52 54 55 23 35 00 0F 03 0B 01 46 90 05 00 00 00 00 00 00 52 41 43 4B 20 31 26 32 00 00 03 02 40 01 46 01 01 00 00 00 00 00 00 52 41 43 4B 20 33 26 34 00 00 03 02 40 01 46 02 01 00 00 00 00 00 00";
    
                var bytes = HexStringToBytes(inputString);
    
                var readableString = Encoding.UTF7.GetString(bytes).ToCharArray();
    
                var paddedReadableString = readableString.Select(ch => char.IsControl(ch) ? '.' : ch).ToArray();
    
                var outputString = new String(paddedReadableString);
                Console.WriteLine(outputString);
                Console.ReadLine();
            }
    
            private static byte[] HexStringToBytes(string hex)
            {
                var strippedHex = Regex.Replace(hex, @"\s+", "");
    
                byte[] raw = new byte[strippedHex.Length / 2];
                for (int i = 0; i < raw.Length; i++)
                {
                    raw[i] = Convert.ToByte(strippedHex.Substring(i * 2, 2), 16);
                }
                return raw;
            }
        }
    }
