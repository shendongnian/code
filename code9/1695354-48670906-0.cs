    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO.Ports;
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                SerialPort myport = new SerialPort();
                myport.BaudRate = 2000000;
                myport.PortName = "COM15";
                myport.Open();
                List<byte> bytes = new List<byte>();
                List<byte> forca = new List<byte>();
                while (true)
                {
                    bytes.Clear();
                    while (true)
                    {
                        if (myport.BytesToRead == 0) continue;
                        int b = myport.ReadByte();
                        if (b < 0) continue; // -1 if end of stream
                        if (b == 13) break; // '\r' in your data
                        bytes.Add((byte)b);
                    }
                
                    if(bytes.Count == 4)
                    {
                        byte[] UnsignedByteArray = bytes.ToArray();
                        sbyte[] SignedByteArray = Array.ConvertAll(UnsignedByteArray, b => unchecked((sbyte)b));
                        if (BitConverter.IsLittleEndian)
                            Array.Reverse(UnsignedByteArray);
                        Console.WriteLine(" "+BitConverter.ToInt32(UnsignedByteArray, 0) * (2.5 / (Math.Pow(2, 31))) * 1000);
                    }
                }
            }
        }
    }
