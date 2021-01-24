    static void Main(string[] args)
    {
        Console.WriteLine("1. option1" +
            Environment.NewLine + "2. option2"+
            Environment.NewLine + "3. option3");
        var ans = Console.ReadLine();
        int choice=0;
        if (int.TryParse(ans, out choice))
        {
            switch (choice)
            {
                case 1:
                    //something for option 1
                case 2:
                    //something for option 2
                case 3:
                    //something for option 3
                default:
                    Console.WriteLine("Wrong selection!!!" +
                        Environment.NewLine + "Press any key for exit");
                    Console.ReadKey();
                    break;
            }
        }
        else
        {
            Console.WriteLine("You must type numeric value only!!!"+
                Environment.NewLine + "Press any kay for exit");
            Console.ReadKey();
        }
    }
