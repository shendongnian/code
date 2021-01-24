        try
        {
            number = Convert.ToInt32(Console.ReadLine());
            if (number >= 18)
                Console.WriteLine("You are old enough to enter");
            else if (number < 18)
                Console.WriteLine("You are not old enough to enter");
        }
        catch
        {
            Console.WriteLine("Only enter a number");
        }
        Console.ReadLine();
