    public static IEnumerable<(int A, int B)> Multipliers(int m)
    {
        yield return (m, 1);
        int i = 2;
        int lastVal = m / 2;
        while (i <= lastVal)
        {
            if (m % i == 0)
            {
                lastVal = m / i;
                yield return (lastVal, i);
            }
            i++;
        }
    }
    public static void Main(string[] args)
    {
        foreach (var pair in Multipliers(16))
        {
            Console.WriteLine("{0}, {1}", pair.A, pair.B);
        }
    }
