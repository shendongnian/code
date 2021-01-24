    using System;
    using System.Diagnostics;
    
    namespace Cli
    {
        class Program
        {
            static void Main(string[] args)
            {
                new Program().TestMethod();
            }
    
            private void TestMethod()
            {
                var sf = new StackFrame(1); //get caller stackframe
                var mi = sf.GetMethod(); //get method info of caller
                Console.WriteLine("{0}::{1}", mi.DeclaringType, mi.Name);
                // Cli.Program::Main
            }
        }
    }
