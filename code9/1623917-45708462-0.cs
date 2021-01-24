    using System;
    namespace ConsoleApp2
    {
        public class Base
        {
            public Base(string param)
            {
                Console.WriteLine("Param: " + param);
            }
        }
        public class Derived : Base
        {
            public Derived(string param) : base(Modify(param))
            {
            }
            static string Modify(string s)
            {
                return "Modified: " + s;
            }
        }
        class Program
        {
            static void Main()
            {
                Derived d = new Derived("Test");
            }
        }
    }
