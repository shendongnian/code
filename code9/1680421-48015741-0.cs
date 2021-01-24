    using System;
    
    namespace ShapeExample
    {
        class Program
        {
            public static void Main(string[] args)
            {
                for (int i = 0; i < 20; i++)
                {
                    var shape = GetRandomShape();
                    shape.Draw();
                }    
            }
    
            public static Random Random = new Random();
            public static Shape GetRandomShape()
            {
                var d = Random.Next(3);
                switch (d)
                {
                    case 1:
                        return new Shape1();
                    case 2:
                        return new Shape2();
                    default:
                        return new Shape3();
                }
            }
        }
    
        public abstract class Shape
        {
            public virtual void Draw()
            {
                //Console.WriteLine("General Shape");
                Console.WriteLine("  _");
                Console.WriteLine(" / \\ ");
                Console.WriteLine("/___\\");
            }
        }
    
        public class Shape1 : Shape
        {
            public override void Draw()
            {
                //Console.WriteLine("I want a square instead");
                Console.WriteLine(" ____");
                Console.WriteLine("|    |");
                Console.WriteLine("|____|");
            }
        }
    
        public class Shape2 : Shape
        {
            public override void Draw()
            {
                //Console.WriteLine("I want a complicated circle instead");
                double r = 3.0;
                double r_in = r - 0.4;
                double r_out = r + 0.4;
    
                for (double y = r; y >= -r; --y)
                {
                    for (double x = -r; x < r_out; x += 0.5)
                    {
                        double value = x * x + y * y;
                        if (value >= r_in * r_in && value <= r_out * r_out)
                        {
                            Console.Write('*');
                        }
                        else
                        {
                            Console.Write(' ');
                        }
                    }
                    Console.WriteLine();
                }
            }
        }
    
        public class Shape3 : Shape
        {
            //I don't care how I look like, I'm using the regular shape drawing.
            
            //but I have some particular info that is not part of a regular Shape
            public int ParticularField { get; }
    
            public Shape3()
            {
                ParticularField = -100;
            }
        }   
    }
