    using System;
    using System.Runtime.InteropServices;
    using RGiesecke.DllExport;
    namespace RSExternalInterface
    {
        public class RSExternalInterface
        {
            [DllExport("add")]
            public static int TestExport(int left, int right)
            {
                int ret = left + right;
                String s = String.Format("C# Func - add: {0} + {1} = {2}", left, right, ret);
                Console.WriteLine(s);
                return ret;
            }
            [DllExport("dbl", CallingConvention = CallingConvention.Winapi)]
            public static int TestExport1(int value)
            {
                int ret = value * 2;
                String s = String.Format("C# Func - dbl: {0} * 2 = {1}", value, ret);
                Console.WriteLine(s);
                return ret;
            }
            [DllExport("none", CallingConvention = CallingConvention.StdCall)]
            public static void TestExport2(int value)
            {
                String s = String.Format("C# Func - none: {0}", value);
                Console.WriteLine(s);
            }
        }
    }
