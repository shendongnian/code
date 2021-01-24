    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Globalization;
    namespace ConsoleApplication7
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.txt";
            static void Main(string[] args)
            {
                StreamReader reader = new StreamReader(FILENAME);
                string input = "";
                List<byte> data = new List<byte>();
                while((input = reader.ReadLine()) != null)
                {
                    string byteStr = input.Substring(6, 3 * 16).Trim();
                    data.AddRange(byteStr.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(x => byte.Parse(x, NumberStyles.HexNumber)));
                }
            }
        }
    }
