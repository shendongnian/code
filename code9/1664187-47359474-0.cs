    private static Random random = new Random();
    private static int MultinomialSample(IReadOnlyList<int> sample, 
        IReadOnlyList<double> probabilities)
    {
        var cumProbs = new double[probabilities.Count];
        cumProbs[0] = probabilities[0];
        for (var i = 1; i < probabilities.Count; i++)
        {
            cumProbs[i] = cumProbs[i - 1] + probabilities[i];
        }
            
        for (var i = 0; i < cumProbs.Length - 1; i++)
        {
            if (random.NextDouble() < cumProbs[i])
            {
                return sample[i];
            }
        }
        return sample[sample.Count - 1];
    }
    private static void Main()
    {
        var iis = new int[7];
        var items = new[] {1, 2, 3, 4, 5, 6};
        var probabilities = new[] {.624, .23, .08, .04, .02, .006};
        for (int i = 0; i < 1000; i++)
        {
            iis[MultinomialSample(items, probabilities)] ++;
        }
        Console.WriteLine(string.Join(", ", iis));
            
        Console.WriteLine("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }
