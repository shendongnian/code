    Console.WriteLine("If you want to add click 1 , subtract click 2");
    int userchoice = int.Parse(Console.ReadLine());
    
    if (userchoice == 1)
    {
        Console.WriteLine("Enter a number");
        int firstinput = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter another number");
        int secondinput = int.Parse(Console.ReadLine());
        Console.WriteLine("Click =");
        string choice = Console.ReadLine();
        if (choice == "=")
        {
            Console.WriteLine(firstinput + secondinput);
        }
    }
        else  if (userchoice == 2)
        {
            Console.WriteLine("Enter a number");
            int firstinput1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter another number");
            int secondinput1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Click =");
            string choice2 = Console.ReadLine();
            if (choice2 == "=")
            {
                Console.WriteLine(firstinput1 - secondinput1);
            }
    }
