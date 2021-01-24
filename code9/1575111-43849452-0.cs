    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.IO;
    using System.Globalization;
    namespace ConsoleApplication50
    {
        class Program
        {
            static void Main(string[] args)
            {
                string[] input = {
                                     "AA 01 00 13 6F BA 8B 18 85 BA 8B 18 0B 01 00 81 00 0D 00 00 C5 BA B5 82 22",
                                     "AA 01 00 13 CA BA 8B 18 E2 BA 8B 18 0C 02 00 81 00 0D 00 00 00 DE 7B D6 39 1F"
                                 };
                CData data = new CData(input);
            }
        }
        public class CData
        {
            public static List<CData> cdata = new List<CData>();
            public byte preamble { get; set; }
            public int version { get; set; }
            public int reserved { get; set; }
            public int cmd { get; set; }
            public byte[] ts1 { get; set; }
            public byte[] ts2 { get; set; }
            public int len { get; set; }
            public byte[] data { get; set; }
            public byte crc { get; set; }
            public CData() { }
            public CData(string[] input)
            {
                foreach (string row in input)
                {
                    List<string> splitArray = row.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    CData newData = new CData();
                    cdata.Add(newData);
                    newData.preamble = byte.Parse(splitArray[0], NumberStyles.HexNumber);
                    newData.version = int.Parse(splitArray[1], NumberStyles.HexNumber);
                    newData.reserved = int.Parse(splitArray[2], NumberStyles.HexNumber);
                    newData.cmd = int.Parse(splitArray[3], NumberStyles.HexNumber);
                    newData.ts1 = splitArray.Skip(4).Take(4).Select(x => byte.Parse(x, NumberStyles.HexNumber)).ToArray();
                    newData.ts2 = splitArray.Skip(8).Take(4).Select(x => byte.Parse(x, NumberStyles.HexNumber)).ToArray();
                    newData.len = int.Parse(splitArray[12], NumberStyles.HexNumber);
                    newData.data = splitArray.Skip(13).Take(len).Select(x => byte.Parse(x, NumberStyles.HexNumber)).ToArray();
                    newData.crc = byte.Parse(splitArray.LastOrDefault(), NumberStyles.HexNumber);
                }
            }
        }
       
    }
