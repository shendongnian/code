    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Diagnostics;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string exe = @"c:\Windows\System32\notepad.exe";
            static void Main(string[] args)
            {
                Process process = new Process();
                ProcessStartInfo info = new ProcessStartInfo(exe);
                process.StartInfo = info;
                process.Start();
            }
        }
     
    }
