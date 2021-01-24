    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Globalization;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string input = "0178 0000 0082 f000 0063 6500 00da 6400 00be 0000 00ff ffff ffff ffff ffd6 6600";
                ConvertHex(input);
            }
            static void ConvertHex(String hexString)
            {
                Int16[] hexArray = hexString.Split(new char[] {' '},StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => Int16.Parse(x, NumberStyles.HexNumber)).ToArray();
                byte[] byteArray = hexArray.Select(x => new byte[] { (byte)((x >> 8) & 0xff), (byte)(x & 0xff) }).SelectMany(x => x).ToArray();
            }
        }
    }
 
