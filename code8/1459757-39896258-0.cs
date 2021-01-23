        static void Main(string[] args)
        {
            int min = 1;
            int max = 100;
            Random rnd = new Random();
        again:
            int gen = rnd.Next(min, max);
            Console.WriteLine("My Number is : " + gen + "!");
            Console.WriteLine("Tell me your number:");
            string typ = Console.ReadLine();
            int num = int.Parse(typ);
            if (num == gen)
            {
                Console.WriteLine(num + " is Equal to " + gen);
            }
            else if (num > gen)
            {
                Console.WriteLine(num + " Is Bigger than " + gen);
            }
            else if (num < gen)
            {
                Console.WriteLine(num + " Is Smaller than " + gen);
            }
         repeat:
            Console.WriteLine("Play again? (Y/N)");
            string ans = Console.ReadLine();
            switch (ans.ToUpper())
            {
                case "Y": goto again; break;
                case "N":  break; //continue
                default: goto repeat; break;
            }
        }
