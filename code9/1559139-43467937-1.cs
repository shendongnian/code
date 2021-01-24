    using System;
    using IntersectLibrary;
    namespace ConsoleApplication
    {
      class Program
      {
        static void Main(string[] args)
        {
          Line straightLine = new StraightLine();
          Line circle = new Circle();
          Circle circle2 = new Circle();
          // Calls "Line.Intersect(Line)", and correctly
          // prints "Circle intersecting a straight line.".
          Console.WriteLine(circle.Intersect(straightLine));
          // Also calls "Line.Intersect(Line)",
          // since the argument's compile-time type is "Line".
          Console.WriteLine(circle2.Intersect(straightLine));
          // Calls "Line.Intersect(Circle)",
          // since the argument's compile-time type is "Circle".
          // At runtime, the call will be resolved to
          // "StraightLine.Intersect(Circle)" via single dispatch.
          Console.WriteLine(straightLine.Intersect(circle2));
          Console.ReadLine();
        }
      }
    }
