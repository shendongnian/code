        class Program
        {
            [StructLayout(LayoutKind.Sequential)]
            public struct AllParameters {
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
                public Parameter[] Parameters;
            }
            [StructLayout(LayoutKind.Sequential)]
            public struct Parameter {
              public int Index;
              public int Id;
              [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
              public byte[] Value;
            }
            [DllImport("exemple.dll", SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool GetAllConsoleParameters(ref IntPtr pItem);
            static void Main(string[] args)
            {
                AllParameters allParameters = new AllParameters();
                IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(allParameters));
                Marshal.StructureToPtr(allParameters,ptr, true);
                AllParameters item = new AllParameters();
                if (GetAllConsoleParameters(ref ptr))
                {
                    var array = item.Parameters;
                }
            }
