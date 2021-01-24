    using System;
    namespace ConsoleApp2
    {
        public abstract class Base
        {
            public Base()
            {
                Console.WriteLine("Base constructor called.");
            }
        }
        public class Derived : Base
        {
        }
        class Program
        {
            static void Main()
            {
                Derived d = new Derived(); // Prints "Base constructor called."
            }
        }
    }
