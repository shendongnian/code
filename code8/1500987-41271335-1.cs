     // I'm using 5 as an example check here.
    for (int outerLoopCounter = 0; outerLoopCounter < 5; outerLoopCounter++)
    {
        Console.WriteLine("Inside Outer Loop:     (:)");
        Console.WriteLine("OUTER:             {0}", outerLoopCounter);
        
        for (int middleLoopCounter = outerLoopCounter + 1; middleLoopCounter < 5; middleLoopCounter++)
        {
            Console.WriteLine("Inside Middle Loop         0 ");
            Console.WriteLine("MIDDLE:            {0}", middleLoopCounter);
            for (int innerLoopCounter = outerLoopCounter + 1; innerLoopCounter < 5; innerLoopCounter++)
            {
                Console.WriteLine("Inside Middle Loop           o");
                Console.WriteLine("INNER:             {0}", innerLoopCounter);
            }
        }
    }
