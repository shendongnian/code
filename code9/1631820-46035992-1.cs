    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                const int count = 1000000;
    
                IList<IItem> items = new List<IItem>(count);
                for (int i = 0; i < count; i++)
                {
                    var rnd = new Random();
                    if (rnd.NextDouble() > 0.5)
                    {
                        items.Add(new ClassA());
                    }
                    else
                    {
                        items.Add(new ClassB());
                    }
                }
    
                var visitor = new MyVisitor();
    
                Stopwatch s = Stopwatch.StartNew();
                for (int i = 0; i < items.Count; i++)
                {
                    items[i].Accept(visitor);
                }
                s.Stop();
    
                Console.WriteLine("ExecTime = {0}, Per Cycle = {1}", s.ElapsedMilliseconds, (double)s.ElapsedMilliseconds / count);
                visitor.Output();
            }
    
            interface IVisitor
            {
                void Process(ClassA item);
                void Process(ClassB item);
            }
    
            interface IItem
            {
                void Accept(IVisitor visitor);
            }
    
            abstract class BaseVisitor : IVisitor
            {
                public virtual void Process(ClassA item)
                {
    
                }
    
                public virtual void Process(ClassB item)
                {
    
                }
            }
    
            class ClassA : IItem
            {
                public void Accept(IVisitor visitor)
                {
                    visitor.Process(this);
                }
            }
    
            class ClassB : IItem
            {
                public void Accept(IVisitor visitor)
                {
                    visitor.Process(this);
                }
            }
    
            class MyVisitor : BaseVisitor
            {
                int a = 0;
                int b = 0;
    
                public override void Process(ClassA item)
                {
                    a++;
                }
    
                public override void Process(ClassB item)
                {
                    b++;
                }
    
                public void Output()
                {
                    Console.WriteLine("a = {0}, b = {1}", a, b);
                }
            }
        }
    }
