        static void Main(string[] args)
        {
            int x;
            int y;
            Console.WriteLine("Welcome to my calculator program!");
            Console.WriteLine("This calculator for now can only do + and -");
            Console.WriteLine("If x is highter than y it will do - and if x is lower than y it will do +");
            Console.WriteLine("pls write in you x");
            x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("pls write in your y");
            y = Convert.ToInt32(Console.ReadLine());
            string opt;
            int res;
            do
            {
                Console.Write("Enter your operator [+/-/:/x]:\t");
                opt= Console.ReadLine();
                res = "/+/-/:/x/".IndexOf("/" + opt + "/");
            } while (res == -1);
            double result;
            switch (opt)
            {
                case "+":
                     result= x + y;
                    break;
                case "-":
                    result = x - y;
                    break;
                case ":":
                    result = (double)x/(double)y;
                    break;
                case "x":
                    result = x*y;
                    break;
                default:
                    result = -9999;
                    break;
            }
            Console.WriteLine("\n{0} {1} {2} = {3}", x, opt, y, result);
            Console.ReadLine();
        }
    }
