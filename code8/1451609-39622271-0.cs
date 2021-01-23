    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    namespace ConsoleExRun
    {
        class Program
        {
            [DllImport("kernel32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            static extern bool AllocConsole();
            static void Main(string[] args)
            {
                AllocConsole();
                Process proc = new Process();
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.FileName = "ping";
                proc.Start();
                Console.ReadLine();
            }
        }
    }
