    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Threading;
    namespace dll {
        class Program {
            static void Main(string[] args) {
                try {
                    Process[] processlist = Process.GetProcesses();
                    foreach(Process process in processlist) {
                        foreach(ProcessModule module in process.Modules) {
                            if(module.FileName.Contains("foo.dll")) {
                                Console.WriteLine(module.FileName);                           
                            }
    
                        }
                    }
                }
                catch(Win32Exception ex) {
                    Console.WriteLine(ex.ToString());
                }
                Console.ReadLine();
            }
        }
    }
