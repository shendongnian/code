    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    
    namespace lekstuga
    {
        class Program
        {
            static void Main(string[] args)
            {
                int loops = 10000000;
    
                for (var n = 0; n < 4; n++)
                {
    
                    Stopwatch stopwatch;
    
                    List<ClassA> listOfClassA2 = new List<ClassA>();
                    List<ClassB> listOfClassB2 = new List<ClassB>();
    
                    for (int i = 0; i < loops; i++)
                    {
                        listOfClassA2.Add(new ClassA(DateTime.Now, 1, 2, 3));
                    }
    
                    stopwatch = Stopwatch.StartNew(); //creates and start the instance of Stopwatch
                    listOfClassB2 = listOfClassA2.ConvertAll((ClassA a) => new ClassB(a));
                    stopwatch.Stop();
    
                    Console.WriteLine("ConvertAll " + stopwatch.ElapsedMilliseconds + "ms");
    
    
                    List<ClassA> listOfClassA = new List<ClassA>();
                    List<ClassB> listOfClassB = new List<ClassB>();
    
                    for (int i = 0; i < loops; i++)
                    {
                        listOfClassA.Add(new ClassA(DateTime.Now, 1, 2, 3));
                    }
    
                    stopwatch = Stopwatch.StartNew(); //creates and start the instance of Stopwatch
                    listOfClassB = listOfClassA.Select(x => new ClassB(x)).ToList();
                    stopwatch.Stop();
    
                    Console.WriteLine("Select " + stopwatch.ElapsedMilliseconds + "ms");
                }
                Console.ReadLine();
            }
    
            class ClassA
            {
                public DateTime Timestamp;
                public double X;
                public double Y;
                public double Z;
    
                public ClassA(DateTime t, double x, double y, double z)
                {
                    Timestamp = t;
                    X = x;
                    Y = y;
                    Z = z;
                }
            }
    
            class ClassB
            {
                public DateTime Timestamp;
                public double X;
    
                public ClassB(ClassA A)
                {
                    Timestamp = A.Timestamp;
                    X = A.X;
                }
            }
        }
    }
