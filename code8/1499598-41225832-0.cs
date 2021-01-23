    using System;
    namespace ConsoleApplication27
    {
        class Program
        {
            private static ObjectCreator creator;
            static void Main(string[] args)
            {
                creator = new CircleCreator();//change this to change the "shape" you get
                Console.ReadLine();
            }
            private static void YourMouseDownMethod()
            {
                creator.CreateObject();//no if statements required, the createObject method does the work
            }
        }
        abstract class ObjectCreator
        {
            public abstract void CreateObject();
        }
        class SquareCreator:ObjectCreator
        {
            public override void CreateObject()
            {
                Console.WriteLine("Create Square");
            }
        }
        class CircleCreator:ObjectCreator
        {
            public override void CreateObject()
            {
                Console.WriteLine("Create Circle");
            }
        }
    }
