    private static int WeightIFeMale()
    {
        Console.WriteLine("How Much Do You Weigh?", Environment.NewLine);
        //int femaleWeight = int.Parse(Console.ReadLine());
        string weigt_st = Console.ReadLine();
        int femaleWeight = 0;
        try
        {
            femaleWeight = int.Parse(weigt_st);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        if (0 >= femaleWeight && 80 <= femaleWeight)
        {
            Console.WriteLine("Damn, how much crack are you smoking?", Environment.NewLine);
        }
        else if (81 >= femaleWeight && 110 <= femaleWeight)
        {
            Console.WriteLine("What the ****, are you a midget *****?", Environment.NewLine);
        }
        else if (111 >= femaleWeight && 140 <= femaleWeight)
        {
            Console.WriteLine("Holy shit, I have some protein bar coupons you can have!", Environment.NewLine);
        }
        else if (141 >= femaleWeight && 160 <= femaleWeight)
        {
            Console.WriteLine("Bro you need to hit the Gym, ASAP!", Environment.NewLine);
        }
        else if (161 >= femaleWeight && 200 <= femaleWeight)
        {
            Console.WriteLine("Really!!!, can I hit the Gym with you?", Environment.NewLine);
        }
        else if
            (201 >= femaleWeight && 240 <= femaleWeight)
        {
            Console.WriteLine("Do you Have a small ****, Steroids are a mother @#$%^&&", Environment.NewLine);
        }
        else if
            (241 >= femaleWeight && 999 <= femaleWeight)
        {
            Console.WriteLine("My condolences!", Environment.NewLine);
        }
        else if
            (femaleWeight >= 1000)
        {
            Console.WriteLine("There is absolutely no way that you weigh {0} lbs, so stop ******* around!", femaleWeight, Environment.NewLine);
        }
        else
        {
            Console.Write("What the **** is {0} It has to be a number numb nuts, lets try that again!", Environment.NewLine);
            WeightIFeMale();
        }
        return femaleWeight;
    }
