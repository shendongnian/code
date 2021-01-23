        static void Main(string[] args)
        {
            double root5 = Math.Sqrt(5);
            double phi = (1 + root5) / 2;
            int input;
            Console.Write("Enter a number : ");
            input = Convert.ToInt32(Console.ReadLine());
            Console.Write("Fibonacci numbers to {0}: ", input);
            Enumerable.Range(0, 80).Select(n => (int)((Math.Pow(phi, n) - Math.Pow(-phi, -(n++))) / (2 * phi - 1))).All(i => { Console.Write("{0} ", i); return i < input; } );
        }
