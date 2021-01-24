    // #define ABC
    using System;
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
    #if ABC
                Func();
            }
            static void Func() {
                Console.WriteLine("Will be printed if ABC is defined.");
    #endif
            }
        }
    }
