    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;
    namespace ConsoleApplication1
    {
        class Program
        {
            [DllImport("XXXXXXXX.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern void myFunction(IntPtr input);
            [StructLayout(LayoutKind.Sequential, Pack = 1)]
            public struct MyInput
            {
                [MarshalAs (UnmanagedType.ByValArray, SizeConst = 3)]
                double[] dArray;
                int a;
                int b;
            }
            static void Main(string[] args)
            {
                MyInput myInput = new MyInput();
                IntPtr dataPtr = Marshal.AllocHGlobal(Marshal.SizeOf(myInput));
                Marshal.StructureToPtr(myInput, dataPtr, true);
                myFunction(dataPtr);
     
            }
        }
        
    }
