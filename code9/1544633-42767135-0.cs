    using System;
    using System.Runtime.CompilerServices;
    
    static class Program
    {
        static void Main() => Console.WriteLine(Compute().ToString("R"));
    
        [MethodImpl(MethodImplOptions.NoInlining)]
        static double Compute() => Math.Sin(182273d) + 0.888d;
    }
