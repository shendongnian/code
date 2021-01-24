    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;
    namespace ConsoleApplication49
    {
        class Program
        {
            [StructLayout(LayoutKind.Sequential)] 
            public struct UnmanagedStruct 
            { 
                [MarshalAs(UnmanagedType.ByValArray)] 
                public IntPtr[] listOfStrings; 
            }
        
            static void Main(string[] args)
            {
                UnmanagedStruct uStruct = new UnmanagedStruct();
                IntPtr strPtr = uStruct.listOfStrings[0];
                List<string> data = new List<string>();
                while (strPtr != IntPtr.Zero)
                {
                    string readStr = Marshal.PtrToStringAnsi(strPtr);
                    data.Add(readStr);
                    strPtr += readStr.Length; //I think it should be Length + 1 to include '\0'
                }
            }
        }
    }
