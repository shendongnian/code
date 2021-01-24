    bool valid = false;
    do
    {
        Console.WriteLine("Give a number");
    
        string w = Console.ReadLine();
    
        double d;
        if (!double.TryParse(w, out d))
        {
            Console.WriteLine("it is not a number");
            valid = false;
        }
        else if (d == number)
        {
            Console.WriteLine("Yes, it is!");
            valid = true;
        }
        else if (wyliczona < wybor) // these conditions seem unrelated to `d`
                                    // are they okay?
        {
            Console.WriteLine("to big number");
            valid = false;
        }
        else if(wyliczona > wybor)
        {
            Console.WriteLine("to small number");
            valid = false;
        }
        else
        {
            Console.WriteLine("unknown condition. needs work.");
            valid = false;
        }
    }
    while (!valid);
