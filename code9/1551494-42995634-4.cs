    using System;
    namespace ConsoleApp2
    {
        public abstract class Base
        {
            public Base()
            {
                Console.WriteLine("Default base constructor called.");
                Value = -1;
            }
            public Base(int value)
            {
                Console.WriteLine("Non-default base constructor called.");
                Value = value;
            }
            public int Value;
        }
        public class Derived : Base
        {
        }
        class Program
        {
            static void Main()
            {
                Derived d = new Derived(); // Prints "Default base constructor called."
            }
        }
    }
