     // I'm using 5 as an example check here.
    for (int outerLoopCounter = 0; outerLoopCounter < 5; outerLoopCounter++)
    {
        Console.WriteLine("OUTER:             {0}", outerLoopCounter);
        
        for (int middleLoopCounter = 0; middleLoopCounter < 5; middleLoopCounter++)
        {
            Console.WriteLine("MIDDLE:              {0}", middleLoopCounter);
            for (int innerLoopCounter = 0; innerLoopCounter < 5; innerLoopCounter++)
            {
                Console.WriteLine("INNER:                 {0}", innerLoopCounter);
            }
        }
    }
