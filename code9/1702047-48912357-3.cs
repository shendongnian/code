    public static IEnumerable<int> ReturnMyNumbers()
    {
        yield return 1;
        yield return 2;
        yield return 3;
        foreach (int i in ReturnMyNumbers())
        {
            Console.WriteLine(i);
        }
    }
