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
                byte[] testMessage = Encoding.UTF8.GetBytes("The quick brown fox jumped over the lazy dog");
                MemoryStream outFile = new MemoryStream();
                BinaryWriter writer = new BinaryWriter(outFile);
                for (int i = 0; i < 10; i++ )
                {
                    writer.Write(BitConverter.GetBytes(testMessage.Length), 0, 4);
                    writer.Write(testMessage, 0, testMessage.Length);
                }
                writer.Flush();
                outFile.Position = 0;
                BinaryReader reader = new BinaryReader(outFile, Encoding.UTF8);
                while (outFile.Position < outFile.Length)
                {
                    int size = reader.ReadInt32();
                    byte[] data = reader.ReadBytes(size);
                }
            }
        }
    }
