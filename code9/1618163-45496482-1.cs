    using System;
    using Antlr4;
    using System.IO;
    using Antlr4.Runtime;
    using Antlr4.Runtime.Misc;
    using Antlr4.Runtime.Tree;
    using System.Collections.Generic;
    using KCompiler.KCore;
    using KCompiler.Assembler;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    
    namespace KCompiler
    {
        public static class NativeMethods
        {
            [DllImport("kernel32.dll")]
            public static extern IntPtr LoadLibrary(string dllToLoad);
    
            [DllImport("kernel32.dll")]
            public static extern IntPtr GetProcAddress(IntPtr hModule, string procedureName);
            [DllImport("kernel32.dll")]
            public static extern bool FreeLibrary(IntPtr hModule);
        }
    
        class Program
        {
            [UnmanagedFunctionPointer(CallingConvention.StdCall)]
            delegate int TestFuncDelegate();
            static int Main(string[] args)
            {
                /*
                AntlrFileStream stream = new AntlrFileStream("../../example.k");
                CLexer lexer = new CLexer(stream);
                CommonTokenStream tokens = new CommonTokenStream(lexer);
                CParser parser = new CParser(tokens);
                ParseTreeWalker tree = new ParseTreeWalker();
                CListener listener = new CListener();
                tree.Walk(listener, parser.file());
                */
    
                KAssembler assembler = new KAssembler();
                assembler.Mov32RI("eax", 32);
    
                string RelativeDirectory = @"..\..";
                string fullAssembly = File.ReadAllText(Path.Combine(RelativeDirectory,"k_template.asm")).Replace("{ASSEMBLY}", assembler.ToString());
                Console.WriteLine(fullAssembly);
                File.WriteAllText(Path.Combine(RelativeDirectory,"k.asm"), fullAssembly);
    
                ProcessStartInfo nasmInfo = new ProcessStartInfo()
                {
                    UseShellExecute = false,
                    FileName = Path.Combine(RelativeDirectory,"nasm.exe"),
                    RedirectStandardOutput = true,
                    Arguments = @"-fwin32 "+ Path.Combine(RelativeDirectory,"k.asm")
                };
    
                using (Process nasm = Process.Start(nasmInfo))
                {
                    nasm.WaitForExit();
                    Console.WriteLine($"NASM exited with code: {nasm.ExitCode}");
                    if (nasm.ExitCode != 0) return nasm.ExitCode;
                }
    
                ProcessStartInfo golinkInfo = new ProcessStartInfo()
                {
                    UseShellExecute = false,
                    FileName = Path.Combine(RelativeDirectory,"GoLink.exe"),
                    RedirectStandardOutput = true,
                    //Arguments = Path.Combine(RelativeDirectory,"k.obj") + " -c -oPE -dll -subsys windows",
                    Arguments = Path.Combine(RelativeDirectory, "k.obj") + " /dll",
                };
    
                using (Process golink = Process.Start(golinkInfo))
                {
                    golink.WaitForExit();
                    Console.WriteLine($"alink exited with code: {golink.ExitCode}");
                    if (golink.ExitCode != 0) return golink.ExitCode;
                }
    
                IntPtr dll = new IntPtr(0);
                try
                {
                    dll = NativeMethods.LoadLibrary(Path.Combine(RelativeDirectory, "k.dll"));
                    Console.WriteLine(dll.ToInt32() == 0 ? "Unable to Load k.dll" : "Loaded k.dll");
                    if (dll.ToInt32() == 0) return 1;
    
                    IntPtr TestFunctionPtr = NativeMethods.GetProcAddress(dll, "testfunc");
                    Console.WriteLine(TestFunctionPtr.ToInt32() == 0 ? "Unable to Load 'testfunc'" : "Loaded 'testfunc'");
                    if (TestFunctionPtr.ToInt32() == 0) return 1;
                    TestFuncDelegate Test = Marshal.GetDelegateForFunctionPointer<TestFuncDelegate>(TestFunctionPtr);
                    int result = Test();
                    Console.WriteLine($"Test Function Returned: {result}");
                }
                finally
                {
                    if(dll.ToInt32() != 0)
                        NativeMethods.FreeLibrary(dll);
                }
          
                return 0;
            }
        }
    }
