    using System.Diagnostics;
    
    namespace YourNameSpace
    {
        class Program
        {
            public static void Main()
            {
                Process[] pcs = Process.GetProcessesByName("YourProcessName");
                string path = pcs[0].MainModule.FileName;
            }
       }
    }
