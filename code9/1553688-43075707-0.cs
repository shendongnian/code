    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;
    namespace ConsoleApplication49
    {
        class Program
        {
            [DllImport("XXXXX.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int Compress(int compressLevel, IntPtr srcBuf, IntPtr outBuf, IntPtr size);   
        
            static void Main(string[] args)
            {
                int compressLevel = 0;
                string input = "The quick brown fox jumped over the lazy dog";
                IntPtr srcBuf = Marshal.StringToBSTR(input);
                IntPtr outBuf = IntPtr.Zero;
                IntPtr size = IntPtr.Zero;
                int results =  Compress(compressLevel, srcBuf, outBuf, size);
                string output = Marshal.PtrToStringAnsi(outBuf);
                long longSize = Marshal.ReadInt64(size);
            }
        }
    }
