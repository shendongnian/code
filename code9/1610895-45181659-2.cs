    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string URL = "enter you url here";
                FileStream sReader = File.OpenRead(URL);
                BinaryReader reader = new BinaryReader(sReader);
                int filenameLength = reader.ReadInt16();
                string filename = Encoding.UTF8.GetString(reader.ReadBytes(filenameLength));
                int year = int.Parse(Encoding.UTF8.GetString(reader.ReadBytes(4)));
                int month = int.Parse(Encoding.UTF8.GetString(reader.ReadBytes(2)));
                int day = int.Parse(Encoding.UTF8.GetString(reader.ReadBytes(2)));
                DateTime date = new DateTime(year, month, day);
                short number1 = reader.ReadInt16();
                int number2 = reader.ReadInt32();
                byte[] data = reader.ReadBytes((int)(reader.BaseStream.Length - reader.BaseStream.Position + 1));
            }
            
        }
    }
