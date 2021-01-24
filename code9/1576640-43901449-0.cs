    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;
    namespace ConsoleApplication50
    {
        class Program
        {
            static void Main(string[] args)
            {
                new Format();
            }
        }
        public class Format
        {
            public enum TYPES
            {
                INT,
                INT16,
                LONG
            }
            public static List<Format> format = new List<Format>() {
                new Format() { name = "AccountNumber", _type = TYPES.INT ,numberOfBytes = 4},
                new Format() { name = "Age", _type = TYPES.INT16 ,numberOfBytes = 2},
                new Format() { name = "AccountNumber", _type = TYPES.LONG ,numberOfBytes = 8}
            };
            public Dictionary<string, object> dict = new Dictionary<string, object>();
            public string name { get; set; }
            public TYPES _type { get; set;  }
            public int numberOfBytes { get; set; }
            public Format() { }
            public Format(byte[] contents)
            {
                MemoryStream stream = new MemoryStream(contents);
                BinaryReader reader = new BinaryReader(stream);
                foreach (Format item in format)
                {
                    switch (item._type)
                    {
                        case TYPES.INT16 :
                            dict.Add(item.name, reader.ReadInt16());
                            break;
                        case TYPES.INT:
                            dict.Add(item.name, reader.ReadInt32());
                            break;
                        case TYPES.LONG:
                            dict.Add(item.name, reader.ReadInt64());
                            break;
                    }
                }
            }
        }
    }
        
