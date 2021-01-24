    WeightedChanceExecutor weightedChanceExecutor = new WeightedChanceExecutor(
        new WeightedChanceParam(() =>
        {
            Console.Out.WriteLine("A");
        }, 25), //25% chance (since 25 + 25 + 50 = 100)
        new WeightedChanceParam(() =>
        {
            Console.Out.WriteLine("B");
        }, 50), //50% chance
        new WeightedChanceParam(() =>
        {
            Console.Out.WriteLine("C");
        }, 25) //25% chance
    );
    //25% chance of writing "A", 25% chance of writing "C", 50% chance of writing "B"        
    weightedChanceExecutor.Execute(); 
