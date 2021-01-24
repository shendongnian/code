    bool valid = false;
    do
    {
        bool newValidState;
        Console.WriteLine("Give a number");
    
        string w = Console.ReadLine();
    
        double d;
        if (!double.TryParse(w, out d))
        {
            Console.WriteLine("it is not a number");
            newValidState = false;
        }
        else if (d == number)
        {
            Console.WriteLine("Yes, it is!");
            newValidState = true;
        }
        else if (wyliczona < wybor) // these conditions seem unrelated to `d`
                                    // are they okay?
        {
            Console.WriteLine("to big number");
            newValidState = false;
        }
        else if(wyliczona > wybor)
        {
            Console.WriteLine("to small number");
            newValidState = false;
        }
        else
        {
            Console.WriteLine("unknown condition. needs work.");
            newValidState = false;
        }
        valid = newValidState;
    }
    while (!valid);
