    // I'm using 10 as an example check here.
    for (int outerLoopCounter = 0; outerLoopCounter < 10; outerLoopCounter++)
    {
        Console.WriteLine("Inside Outer Loop");
        Console.WriteLine("outerLoopCounter: {0}", outerLoopCounter);
        
        for (int middleLoopCounter = outerLoopCounter + 1; middleLoopCounter < 10; middleLoopCounter++)
        {
            Console.WriteLine("Inside Middle Loop");
            Console.WriteLine("middleLoopCounter: {0}", middleLoopCounter);
            for (int innerLoopCounter = outerLoopCounter + 1; innerLoopCounter < 10; innerLoopCounter++)
            {
                Console.WriteLine("Inside Middle Loop");
                Console.WriteLine("innerLoopCounter: {0}", innerLoopCounter);
            }
        }
    }
