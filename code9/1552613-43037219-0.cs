    using System.Console;
    class MainClass
    {
        static int[] A() { Write("A"); return new int[] { 23 }; }
        static int   B() { Write("B"); return 0; }
        static int   C() { Write("C"); return 42; }
        public static void Main()
        {
            WriteLine("Compound Assignment:");
            A()[B()] += C();
            // ABC
            WriteLine("\nExplicit Assignment:");
            A()[B()] = A()[B()] + C();
            // ABABC
        }
    }
