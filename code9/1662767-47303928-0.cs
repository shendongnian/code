    using System;
    using System.Runtime.InteropServices;
    namespace ConsoleApp3
    {
        class Program
        {
            static void Main()
            {
                double s = -2.6114289999999998;
                Console.WriteLine(Math.Round(s, 7).ToString("R")); // -2.611429
                if (!Environment.Is64BitProcess)
                    _controlfp(0x00030000, 0x00020000);
                Console.WriteLine(Math.Round(s, 7).ToString("R")); // -2.61142897605896
            }
            [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
            static extern uint _controlfp(uint newcw, uint mask);
        }
    }
