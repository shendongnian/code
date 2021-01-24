    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Runtime.InteropServices;
    using System.Diagnostics;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            const int PROCESS_WM_READ = 0x0010;
    
            [DllImport("kernel32.dll")]
            public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);
    
            [DllImport("kernel32.dll")]
            public static extern bool ReadProcessMemory(int hProcess,
            Int64 lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);
    
            static void Main(string[] args)
            {
                Process process = Process.GetProcessesByName("Tutorial-x86_64")[0];
                IntPtr processHandle = OpenProcess(PROCESS_WM_READ, false, process.Id);
    
                int bytesRead = 0;
                byte[] buffer = new byte[4];
    
                
                //Byte[] buffer = new Byte[4];
    
                Int64 baseAddress = 0x1002CAA70;
                ReadProcessMemory((int)processHandle, baseAddress, buffer, buffer.Length, ref bytesRead);
                Int64 baseValue = BitConverter.ToInt32(buffer, 0);
    
                Int64 firstAddress = baseValue + 0x10;
                ReadProcessMemory((int)processHandle, firstAddress, buffer, buffer.Length, ref bytesRead);
                Int64 firstValue = BitConverter.ToInt32(buffer, 0);
    
                Int64 secondAddress = firstValue + 0x18;
                ReadProcessMemory((int)processHandle, secondAddress, buffer, buffer.Length, ref bytesRead);
                Int64 secondValue = BitConverter.ToInt32(buffer, 0);
    
                Int64 thirdAddress = secondValue + 0x0;
                ReadProcessMemory((int)processHandle, thirdAddress, buffer, buffer.Length, ref bytesRead);
                Int64 thirdValue = BitConverter.ToInt32(buffer, 0);
    
                Int64 fourthAddress = thirdValue + 0x18;
                ReadProcessMemory((int)processHandle, fourthAddress, buffer, buffer.Length, ref bytesRead);
                Int64 fourthValue = BitConverter.ToInt32(buffer, 0);
    
                ReadProcessMemory((int)processHandle, fourthValue, buffer, buffer.Length, ref bytesRead);
                Console.WriteLine(BitConverter.ToInt32(buffer, 0));
                Console.ReadLine();
            }
        }
    }
