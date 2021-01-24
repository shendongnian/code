    namespace JunkProject
    {
        class Program
        {
            static void Main(string[] args)
            {
                int test = initiate(.05, .05, 60, "1");
    
                Console.WriteLine(test);
                if (test != 1)
                    Console.ReadLine();
    
                Structure[] structure = new Structure[1];
                structure[0].ValueName = "Test1";
                structure[0].Value = Marshal.AllocHGlobal(28);
                // alternatively:
                // structure[0].Value = (IntPtr) Marshal.StringToHGlobalAnsi("TESTTESTTESTTESTTESTTESTTEST");
                structure[0].Status = 0;
                structure[0].ReturnVal1 = 0.0;
                structure[0].ReturnVal2 = 0.0;
                structure[0].ReturnVal3 = 0.0;
                structure[0].Temp = 0.0;
                test = DoWork(1, structure);
    
                String Value = Marshal.PtrToStringAnsi(structure[0].Value);
                Console.WriteLine(Value);
                Console.ReadLine();
                Marshal.FreeHGlobal(structure[0].Value);
            }
    
            private const string DLL_LOCATION = "CustomDLL.dll";
    
            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
            public struct Structure
            {
                [MarshalAs(UnmanagedType.LPStr)]
                public string ValueName;
                public IntPtr Value;
                public int Status;
                public double ReturnVal1;
                public double ReturnVal2;
                public double ReturnVal3;
                public double Temp;
            }
            [DllImport(DLL_LOCATION, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "_initiate")]
            private static extern int initiate(double Conc1, double Conc2, int Temp, [MarshalAs(UnmanagedType.LPStr)] string Type);
    
            [DllImport(DLL_LOCATION, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "_DoWork")]
            private static extern int DoWork(int NumItems, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex=0)] Structure[] Struct);
        }
    }
