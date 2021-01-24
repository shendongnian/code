    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;
    namespace ConsoleApplication74
    {
        class Program
        {
            [DllImport("mydll.dll")]
            public static extern int toGetInfo(uint id, IntPtr strVolume, IntPtr strInfo);
            [DllImport("mydll.dll")]
            public static extern int toOpen(uint id, IntPtr name);
            const int STRING_LENGTH = 256;
            static void Main(string[] args)
            {
                IntPtr strVolumePtr = Marshal.AllocHGlobal(STRING_LENGTH);
                IntPtr strInfoPtr = Marshal.AllocHGlobal(STRING_LENGTH);
                uint id = 123;
                int status1 = toGetInfo(id, strVolumePtr, strInfoPtr);
                string strVolume = Marshal.PtrToStringAnsi(strVolumePtr);
                string strInfo = Marshal.PtrToStringAnsi(strInfoPtr);
                string name = "John";
                IntPtr openNamePtr = Marshal.StringToHGlobalAnsi(name);
                int status2 = toOpen(id, openNamePtr);
            }
        }
    }
