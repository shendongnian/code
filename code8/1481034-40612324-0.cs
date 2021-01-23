    using System;
    using System.Collections;
    namespace ConsoleApplication3
    {
        class A
        {
            public int a = 100;
        }
        class Program
        {
            static void Main(string[] args)
            {
                var list = new ArrayList();
                A a = new A();
                list.Add((int)typeof(A).GetField("a").GetValue(a));
                foreach (var i in list)
                {
                    Console.WriteLine(i);
                }
                Console.ReadKey();
            }
        }
    }
