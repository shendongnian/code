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
    else if (userchoice == 2)
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
    else
    {
       Console.WriteLine("Wrong Selection, either select 1 or 2");
    }
