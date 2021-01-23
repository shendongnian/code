    using System;
    
    namespace CSTest
    {
      class Program
      {
        static void Main(string[] args)
        {
          var handle = MyWin32.CreateToolhelp32Snapshot(new IntPtr(4), new IntPtr(System.Diagnostics.Process.GetCurrentProcess().Id));
          Console.WriteLine(handle);
          Console.WriteLine(MyWin32.CloseHandle(handle));
    
          Console.ReadLine();
        }
      }
    }
