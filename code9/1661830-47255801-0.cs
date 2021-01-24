        using System;
    
    namespace ex
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                double s, area;
                double a, b, c;
                
                Console.WriteLine("Enter side #1");
                a = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter side #2");
                b = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter side #3");
                c = double.Parse(Console.ReadLine());
                
                s = (a + b + c) / 2;
                area = Math.Sqrt(s * ( s - a) * (s - b) * (s - c)); 
                
                Console.WriteLine("Area = {0}", area);
            }
        }
    }
