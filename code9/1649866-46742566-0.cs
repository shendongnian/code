    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.txt";
            static void Main(string[] args)
            {
                StreamReader reader = new StreamReader(FILENAME);
                string inputLine = "";
                List<byte> data = new List<byte>();
                while ((inputLine = reader.ReadLine()) != null)
                {
                    string[] splitArray = inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                    foreach(string hexNumberStr in splitArray)
                    {
                        byte hexNumber = byte.Parse(hexNumberStr, System.Globalization.NumberStyles.HexNumber);
                        data.Add(hexNumber);
                    }
                }
                reader.Close();
            }
        }
    }
