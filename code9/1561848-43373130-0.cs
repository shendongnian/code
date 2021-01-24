    using System;
    using System.Collections;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Stack stack = new Stack();
                stack.Push("First Item");
                stack.Push("Second Item");
                Console.WriteLine(stack.Pop());
                Console.WriteLine(stack.Pop());
                Console.ReadKey();
            }
        }
    }
