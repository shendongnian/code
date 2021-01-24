    public static IEnumerable<(int A, int B)> Multipliers(int m)
    {
        yield return (m, 1);
        int lastVal = int.MaxValue;
        for (int i = 2; i <= lastVal; i++)
        {
            if (m % i == 0)
            {
                lastVal = m / i;
                yield return (lastVal, i);
            }
        }
    }
    public static void Main(string[] args)
    {
        foreach (var pair in Multipliers(16))
        {
            Console.WriteLine("{0}, {1}", pair.A, pair.B);
        }
    }
