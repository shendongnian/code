    private static void ShowGenes(List<bool[]> genes)
    {
        foreach (var gene in genes)
        {
            foreach (var bit in gene)
            {
                Console.Write(bit ? "1" : "0");
            }
            Console.Write("\n");
        }
    }
