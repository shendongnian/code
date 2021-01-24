    public static IEnumerable<(int A, int B)> Multipliers(int m)
    {
        yield return (m, 1);
        int lastVal = (int)Math.Sqrt(m);
        int increment = m % 2 == 0 ? 2 : 1;
        int i = m % 2 == 0 ? 3 : 2;
        while (i <= lastVal)
        {
            if (m % i == 0)
            {
                lastVal = m / i;
                yield return (lastVal, i);
            }
            i += increment;
        }
    }
