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
                string input = "78780D01012345678901234500018CDD0D0A";
              
                byte[] bytes = Unpack(input);
                byte[] serialNumber = bytes.Skip(bytes.Length - 2).ToArray();
                byte[] response = { 0x78, 0x78, 0x05, 0x01, 0x00, 0x00, 0x00, 0x0 };
                serialNumber.CopyTo(response, 4);
                UInt16 sendCRC = crc_bytes(response.Take(response.Length - 2).ToArray());
                response[response.Length - 2] = (byte)((sendCRC >> 8) & 0xFF);
                response[response.Length - 1] = (byte)((sendCRC) & 0xFF);
            }
            static byte[] Unpack(string data)
            {
                //return null indicates an error
                List<byte> bytes = new List<byte>();
                // check start and end bytes
                if ((data.Substring(0, 4) != "7878") && (data.Substring(data.Length - 4) != "0D0A"))
                {
                    return null;
                }
                for (int index = 4; index < data.Length - 4; index += 2)
                {
                    bytes.Add(byte.Parse(data.Substring(index, 2), System.Globalization.NumberStyles.HexNumber));
                }
                //crc test
                byte[] packet = bytes.Take(bytes.Count - 2).ToArray();
                byte[] crc = bytes.Skip(bytes.Count - 2).ToArray();
                uint CalculatedCRC = crc_bytes(packet);
                //if (CalculatedCRC != BitConverter.ToUInt16(crc, 0))
                //{
                //    return null;
                //}
                return packet;
            }
            public static UInt16 crc_bytes(byte[] data)
            {
                ushort crc = 0xFFFF;
                for (int i = 0; i < data.Length; i++)
                {
                    crc ^= (ushort)(data[i] << 8);
                    for (int j = 0; j < 8; j++)
                    {
                        if ((crc & 0x8000) > 0)
                            crc = (ushort)((crc << 1) ^ 0x1021);
                        else
                            crc <<= 1;
                    }
                }
                
                return crc;
            }
        }
    }
