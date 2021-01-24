    public static void PrintAllPermutations()
    {
        var input = new[] {5, 2, 1, 4};
        var prefix = input.Skip(2).Take(input[1]).ToList();
        var suffx = Enumerable.Range(1, input[0]).Except(prefix).ToList();
        foreach (var permutation in Permute(prefix, suffx))
            Console.WriteLine(string.Join(", ", permutation));
    }
