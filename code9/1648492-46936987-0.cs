    using System;
    
    class Program {
        static void Main(string[] args) {
            var obj = new Example();
            obj = null;    // Avoid debugger extending its lifetime
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Console.ReadLine();
        }
    }
    
    class Base { ~Base() { Console.WriteLine("Base finalizer called"); } }
    class Derived : Base { ~Derived() { Console.WriteLine("Derived finalizer called"); } }
    class Example : Derived { }
