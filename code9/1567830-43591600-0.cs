    public bool Generation()
    {
        TotalGenerationNumber++;
        // Work
        return HasReachedGoal;
    }
    static void Main(string[] args)
    {
        Population population = new Population();
        bool hasCompleted = false;
        while (!hasCompleted) // Until it reaches its goal
        {
            hasCompleted = population.Generation();
        }
        Console.WriteLine("End. Generations: " + population.TotalGenerationNumber);
    }
