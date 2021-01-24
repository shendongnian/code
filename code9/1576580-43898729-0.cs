    class Program
    {
        static void Main(string[] args)
        {                       
            Console.Title = "5";
            Console.ForegroundColor = ConsoleColor.Blue;
            // ________________________________________________________
            loop:
            Console.WriteLine("\n \t This is your bag!");
            Console.WriteLine("\t [1] to pack things");
            Console.WriteLine("\t [2] to pack things in the outercompartment");
            Console.WriteLine("\t [3] to see packed things");
            Console.WriteLine("\t [4] to quit");
            Console.WriteLine("\t your choice: ");
            string str = Console.ReadLine();
            int nr = Convert.ToInt32(str);
            List<string> items = new List<string>();
            items.Add(str);
    
            switch (nr)
            {
                case 1:
                    packing:
                    Console.Write("What would you like to pack? [QUIT for menu]\t");
                    str = Console.ReadLine();
                    if (str=="QUIT") goto loop;
                    items.add(str);
                    Console.WriteLine("You packed a " + str);
                    goto packing;
                    break;
                case 4:
                    goto quitloop;
            }
    
            Console.ReadKey();
            goto loop;
        }
    quitloop:
    }
