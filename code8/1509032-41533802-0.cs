    namespace NS
    {
        class Program
        {
            static void Main()
            {
                var _a1 = new A();
                var _a2 = new A(123);
    
                System.Console.ReadKey();
            }
        }
    
        public partial class A
        {
            public A()
            {
                System.Console.WriteLine("Hi from A (parameterless)");
            }
        }
    
        public partial class A
        {
            public A(int MyParam)
            {
                System.Console.WriteLine("Hi from A (int)");
            }
        }
    }
    
