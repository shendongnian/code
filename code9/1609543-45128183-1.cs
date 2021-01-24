    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<List<byte>> inputs = new List<List<byte>>() {
                     new List<byte>() {0x40, 0x30, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00},
                     new List<byte>() {0xC0, 0x62, 0x2E, 0xB8, 0x60, 0x00, 0x00, 0x00},
                     new List<byte>() {0x40, 0x90, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00},
            };
                foreach (List<byte> input in inputs)
                {
                    input.Reverse();
                    Console.WriteLine(BitConverter.ToDouble(input.ToArray(),0));
                }
                Console.ReadLine();
            }
        }
    }
