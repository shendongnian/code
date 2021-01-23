    class Program
    {
        static void Main(string[] args)
        {
            double a, b, c, x1, x2, x, D;
            String A;
            String B;
            String C;
            Console.Write("a=");
            A = Console.ReadLine();
            Console.Write("b=");
            B = Console.ReadLine();
            Console.Write("c=");
            C = Console.ReadLine();
            a = Convert.ToDouble(A);
            b = Convert.ToDouble(B);
            c = Convert.ToDouble(C);
            D = (b * b - 4 * a * c);
            if (D > 0)
            {
                x1 = (-b + Math.Sqrt(D)) / (2 * a);
                x2 = (-b - Math.Sqrt(D)) / (2 * a);
                Console.WriteLine("x1=" + x1);
                Console.WriteLine("x2=" + x2);
            }
            else
            {
                if (D < 0)
                {
                    D = -D;
                    //x1 = (-b + Math.Sqrt(D)) / (2 * a);
                    //x2 = (-b - Math.Sqrt(D)) / (2 * a);
                    string complexX1 = ((-b) / (2 * a)).ToString() + "+" + (Math.Sqrt(D) / 2 * a).ToString() + "i";
                    string complexX2 = ((-b) / (2 * a)).ToString() + "-" + (Math.Sqrt(D) / 2 * a).ToString() + "i";
                    Console.WriteLine("complex x1=" + complexX1);
                    Console.WriteLine("complex x2=" + complexX2);
                }
                else
                {
                    x = (-b / (2 * a));
                    Console.WriteLine("x=" + x);
                }
            }
            Console.ReadKey();
        }
