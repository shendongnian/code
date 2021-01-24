    using System;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Security;
    using EnvDTE80;
    using Process = System.Diagnostics.Process;
    
    namespace StartService
    {
        class Program
        {
            static void Main(string[] args)
            {
                var secure = new SecureString();
                foreach (var c in "password-from-config")
                {
                    secure.AppendChar(c);
                }
    
                Process process = null;
    
                try
                {
                    process = Process.Start(@"C:\Test Projects\WcfServiceTest\WcfServiceTest\bin\Debug\WcfServiceTest.exe",
                        "TestUser", secure, "DomainName");
                    
                    Attach(GetCurrent());
                    
                    Console.ReadKey();
                }
                finally
                {
                    if (process != null && !process.HasExited)
                    {
                        process.CloseMainWindow();
                        process.Close();
                    }    
                }
            }
    
            public static void Attach(DTE2 dte)
            {
                var processes = dte.Debugger.LocalProcesses;
                foreach (var proc in processes.Cast<EnvDTE.Process>().Where(proc => proc.Name.IndexOf("WcfServiceTest.exe") != -1))
                    proc.Attach();
            }
    
            internal static DTE2 GetCurrent()
            {
                var dte2 = (DTE2)Marshal.GetActiveObject("VisualStudio.DTE.12.0"); // Specific to VS2013
    
                return dte2;
            }
        }
    }
