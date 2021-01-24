    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Runtime.InteropServices;
    namespace ConsoleApp
    {
        class Program
        {
            [DllImport("shlwapi.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern int SHLoadIndirectString(string pszSource, StringBuilder pszOutBuf, int cchOutBuf, IntPtr ppvReserved);
            static void Main(string[] args)
            {
                StringBuilder buffer = new StringBuilder(1024);
    
                string resourcePath = "@FirewallAPI.dll,-32752";
    
                int result = SHLoadIndirectString(resourcePath, buffer, buffer.Capacity, IntPtr.Zero);
    
                if (result == 0) Console.WriteLine(buffer.ToString()); // return "Network Discovery" on Windows 10 (1607)
    
                Console.ReadKey();
            }
        }
    }
