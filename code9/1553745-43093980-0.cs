    static class NativeMethods {
        [DllImport("trample.dll", CharSet = CharSet.Unicode)]
        public static extern void Trample(string text);
    }
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello, world!");
            NativeMethods.Trample("Hello, world!");
            Console.WriteLine("Hello, world!");
        }
    }
