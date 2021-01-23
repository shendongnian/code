    using System;
    namespace ConsoleApplication1
    {
      abstract class Shape
      {
        public abstract string GetArea();
        public abstract string Display();
        public abstract string GetPerimeter();
        public override string ToString()
        {
          return Display() + ": " + GetArea() + ", " + GetPerimeter();
        }
      }
      class Circle : Shape
      {
        public Circle(double r)
        {
          this.r = r;
        }
        double r;
        public override string GetArea()
        {
          return "Circle area =" + Math.PI*Math.Pow(r, 2);
        }
        public override string GetPerimeter()
        {
          return "Circle circumference = " + 2*Math.PI*r;
        }
        public override string Display()
        {
          return "This is Circle";
        }
      }
      class Rect : Shape
      {
        public Rect(double x, double y)
        {
          this.x = x;
          this.y = y;
        }
        double x, y;
        public override string GetArea()
        {
          return "Rectangle area =" + x*y;
        }
        public override string GetPerimeter()
        {
          return "Circle circumference = " + (2*x + 2*y);
        }
        public override string Display()
        {
          return "This is Rectangle";
        }
      }
      class Square : Shape
      {
        public Square(double z)
        {
          this.z = z;
        }
        double z;
        public override string GetArea()
        {
          return "Square area =" + z*z;
        }
        public override string GetPerimeter()
        {
          return "Square perimeter = " + 4*z;
        }
        public override string Display()
        {
          return "This is Square";
        }
      }
      class Program
      {
        static void Main(string[] args)
        {
          var sh = new Shape[15];
          var rndm = new Random();
          for (var i = 0; i < 15; i++)
          {
            switch (rndm.Next(1, 4))
            {
              case 1:
                Console.WriteLine("Enter radius");
                sh[i] = new Circle(int.Parse(Console.ReadLine()));
                break;
              case 2:
                Console.WriteLine("Enter x and y lengths");
                double x = double.Parse(Console.ReadLine());
                double y = double.Parse(Console.ReadLine());
                sh[i] = new Rect(x, y);
                break;
              case 3:
                Console.WriteLine("Enter side length");
                sh[i] = new Square(int.Parse(Console.ReadLine()));
                break;
            }
          }
          foreach (var shape in sh)
            Console.WriteLine(shape);
          Console.ReadLine();
        }
      }
    }
