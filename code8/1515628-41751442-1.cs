    using System;
    using System.Runtime.InteropServices;
    
    namespace ConsoleApplication1
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                var intPtr = Test();
                var ptrToStructure = Marshal.PtrToStructure<Test1>(intPtr);
            }
    
            [DllImport("MyDLL.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr Test();
        }
    
        [StructLayout(LayoutKind.Sequential)]
        internal struct Test1
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public readonly int[] data1;
    
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public readonly int[] data2;
    
            public readonly int data3;
            public readonly int data4;
        }
    }
