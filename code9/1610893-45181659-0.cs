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
                DateTime date = DateTime.Parse(Encoding.UTF8.GetString(reader.ReadBytes(8)));
                short number1 = reader.ReadInt16();
                int number2 = reader.ReadInt32();
                byte[] data = reader.ReadBytes((int)(reader.BaseStream.Length - reader.BaseStream.Position + 1));
            }
            
        }
    }
