    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;
    namespace ConsoleApplication73
    {
        class Program
        {
            [DllImport("hdnpic.dll")]
            public static extern int Hidden(IntPtr hid4cinp);
            [StructLayout(LayoutKind.Sequential)]
            public struct Hid4cinp
            {
                public const int maxSize = 500;
                public double alpha_c;
                public double alpha_m;
                public double alpha_y;
                public double alpha_k;
                public double freq;
                public double dsmp;
                public double cdxy;
                public double cdhi_c;
                public double cdhi_m;
                public double cdhi_y;
                public double cdhi_k;
                public double amp1;
                public double perd;
                public int funtype;
                public int smooth;
                public int inpres;
                public int width;
                public int height;
            }        
            static void Main(string[] args)
            {
                Hid4cinp hid4cinp = new Hid4cinp();
                hid4cinp.alpha_c = 123;
                IntPtr hid3cinpPtr = Marshal.AllocHGlobal(Marshal.SizeOf(hid4cinp));
                Marshal.StructureToPtr(hid4cinp, hid3cinpPtr, true);
                int results = Hidden(hid3cinpPtr);
            }
        }
    }
