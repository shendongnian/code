    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;
    using System.Drawing;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string DllFilePath = @"c:\temp";
            [DllImport(DllFilePath, EntryPoint = "test", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
            private static extern int _test(ref IntPtr memory, out IntPtr size);
            static void Main(string[] args)
            {
            }
            public static void Test()
            {   
                IntPtr memory = IntPtr.Zero;
                IntPtr _size = IntPtr.Zero;
                _test(ref memory, out _size);
                int size = (int)Marshal.PtrToStructure(_size, typeof(int));
                byte[] memoryArray = new byte[size];
                Marshal.Copy(memory, memoryArray, 0, size);
                Bitmap bmp;
                using (var ms = new MemoryStream(memoryArray))
                {
                    bmp = new Bitmap(ms);
                }
                bmp.Save("test_recreated.png");
            }
        }
    }
