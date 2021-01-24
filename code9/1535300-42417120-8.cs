    using System;
    namespace NullCheckTest
    {
        class Program
        {
            const int iterations = 10000000;
            static void Main(string[] args)
            {
                MyClass valueClass = new MyClass() { Value = 10 };
                MyClass nullClass = null;
                Console.WriteLine($"valueClass with null check = {TestNullCheck(valueClass)}");
                Console.WriteLine($"nullClass with null check = {TestNullCheck(nullClass)}");
                Console.WriteLine($"valueClass with no null check = {TestNoNullCheck(valueClass)}");
                Console.WriteLine($"nullClass with no null check = {TestNoNullCheck(nullClass)}");
                Console.ReadLine();
            }
            static long TestNullCheck(MyClass myClass)
            {
                MyClass initial = myClass;
                System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                for (int i = 0; i < iterations; ++i)
                {
                    sw.Start();
                    if (myClass != null)
                    {
                        myClass = null;
                    }
                    sw.Stop();
                    myClass = initial;
                }
                return sw.ElapsedMilliseconds;
            }
            static long TestNoNullCheck(MyClass myClass)
            {
                MyClass initial = myClass;
                System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                for (int i = 0; i < iterations; ++i)
                {
                    sw.Start();
                
                    myClass = null;
                    sw.Stop();
                    myClass = initial;
                }
                return sw.ElapsedMilliseconds;
            }
        }
        public class MyClass
        {
            public int Value { get; set; }
        }
    }
