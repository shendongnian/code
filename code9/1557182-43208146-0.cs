    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Runtime.InteropServices;
    using System.IO;
    namespace ConsoleApplication49
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct Data
        {
            [MarshalAs(UnmanagedType.I8)]
            public Int64 timestamp;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 600 * 16)]
            public byte[,] dataBlock1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 600 * 16)]
            public byte[,] dataBlock2;
        }
        class Program
        {
            
            const string FILENAME = @"c:\temp\test.bin";
            static void Main(string[] args)
            {
                Stream oStream = File.OpenWrite(FILENAME);
                BinaryWriter writer = new BinaryWriter(oStream);
                int size = Marshal.SizeOf(typeof(Data));
                byte[] oBuffer = new byte[size];
                writer.Write(oBuffer);
                writer.Flush();
                writer.Close();
                Stream iStream = File.OpenRead(FILENAME);
                BinaryReader reader = new BinaryReader(iStream);
                
                while (!((iStream.Position + size) < iStream.Length))
                {
                   
                    IntPtr ptr = Marshal.AllocHGlobal(size);
      
                    byte[] buffer = reader.ReadBytes(size);
                    Marshal.Copy(buffer, 0, ptr, size);
                    Data data = (Data)Marshal.PtrToStructure(ptr, typeof(Data));
                }
                
            }
        }
     
       
    }
