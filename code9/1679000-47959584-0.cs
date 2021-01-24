    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
             public struct Termios {
              public uint c_cc1 { get; set; }
              public uint c_cc2 { get; set; }
              public uint c_cflag { get; set; }
              public uint c_iflag { get; set; }
              public uint  c_lflag  { get; set; }
              public uint c_oflag { get; set; }
              public uint c_ispeed { get; set; }
              public uint c_ospeed { get; set; }
            };
            static void Main(string[] args)
            {
                //Byte#   B38400  B9600
                byte[,] input = {
                                     {0,5, 0,0,5,0,0,0,191, 12,0,0,59,138, 0,0,0,3,127,21,4,0,0,0,17,19,26,0,18,15, 23,22},
                                     {0,5, 0,0,5,0,0,0,189, 12,0,0,59,138, 0,0,0,3,127,21,4,0,1,0,17,19,26,0,18,15, 23,22}
                                 };
                Termios[] termios = new Termios[2];
                for(int i = 0; i < 2; i++)
                {
                    termios[i].c_cc1 = BitConverter.ToUInt32(input.Cast<byte>().Skip(i * 32).ToArray(),0);
                    termios[i].c_cc2 = BitConverter.ToUInt32(input.Cast<byte>().Skip(i * 32).ToArray(), 4);
                    termios[i].c_cflag = BitConverter.ToUInt32(input.Cast<byte>().Skip(i * 32).ToArray(), 8);
                    termios[i].c_iflag = BitConverter.ToUInt32(input.Cast<byte>().Skip(i * 32).ToArray(), 12);
                    termios[i].c_lflag = BitConverter.ToUInt32(input.Cast<byte>().Skip(i * 32).ToArray(), 16);
                    termios[i].c_oflag = BitConverter.ToUInt32(input.Cast<byte>().Skip(i * 32).ToArray(), 20);
                    termios[i].c_ispeed = BitConverter.ToUInt32(input.Cast<byte>().Skip(i * 32).ToArray(), 24);
                    termios[i].c_ospeed = BitConverter.ToUInt32(input.Cast<byte>().Skip(i * 32).ToArray(), 28);
                }
            }
        }
    }
