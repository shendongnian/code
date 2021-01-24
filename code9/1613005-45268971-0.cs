    static void Main(string[] args)
    {
        foreach (var li in BreakMeDown(7))
            Console.WriteLine(string.Join(", ", li));
    }
    public static IEnumerable<IReadOnlyCollection<int>> BreakMeDown(int n)
    {
        for (int i = 1, j = n - 1; i <= j; i++, j--)
        {
            foreach (var li in BreakMeDown(j).Select(bd => bd.Concat(new[] {i}).ToList()))
                yield return li;
            foreach (var li in BreakMeDown(i).Select(bd => bd.Concat(new[] {j}).ToList()))
                yield return li;
            yield return new[] {i, j};
        }
    }
