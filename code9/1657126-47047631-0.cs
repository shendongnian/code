    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;
    namespace ConsoleApplication1
    {
        class Program
        {
            public enum STATUS : int //make sure correct size
            {
                // add items
            }
            [DllImport("myDLL")]
            public static extern STATUS fillArray(IntPtr floatArrayPtr, IntPtr countPtr);
            const int MAX_ARRAY_SIZE = 100;
            static void Main(string[] args)
            {
                int count = MAX_ARRAY_SIZE;
                IntPtr arrayPtr = Marshal.AllocHGlobal(MAX_ARRAY_SIZE * sizeof(float));
                IntPtr countPtr = IntPtr.Zero;
                Marshal.StructureToPtr(count, countPtr, true);
                STATUS status = fillArray(arrayPtr, countPtr);
                float[] floatArray = new float[MAX_ARRAY_SIZE];
                Marshal.Copy(arrayPtr, floatArray, 0, count);
                Marshal.FreeHGlobal(arrayPtr);
                Marshal.FreeHGlobal(countPtr);
            }
        }
    }
