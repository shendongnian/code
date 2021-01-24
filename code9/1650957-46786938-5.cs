    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Threading;
    namespace dll {
        class Program {
            static void Main(string[] args) {
                try {
                    while(true) {
                        int noErrorCount = 0;
                        int errorCount = 0;
                        Process[] processlist = Process.GetProcesses();
                        foreach(Process process in processlist) {
    
                            try {
                                foreach(ProcessModule module in process.Modules) {
                                    if(module.FileName.ToLower().Contains("Kernel32.dll".ToLower())) {
                                        Console.WriteLine(module.FileName);
                                    }
                                    //Console.WriteLine(module.FileName);
                                    noErrorCount++;
                                }
                            }
                            catch(Win32Exception ex) {
                                errorCount++;
                            }
                        }
                        Console.WriteLine("Modules checked: " + noErrorCount);
                        Console.WriteLine("Modules with error(not checked): " + errorCount);
                    }
                }
                catch(Exception ex) {
                    Console.WriteLine(ex.ToString());
                    Console.ReadLine();
                }
            }
        }
    }
