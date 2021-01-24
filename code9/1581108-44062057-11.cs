    public static IEnumerable<(int A, int B)> Multipliers(int m)
    {
        yield return (m, 1);
        int finalVal = (int)Math.Sqrt(m);
        int increment = m % 2 != 0 ? 2 : 1;
        int i = m % 2 != 0 ? 3 : 2;
        while (i <= finalVal)
        {
            if (m % i == 0)
            {
                yield return (m / i, i);
            }
            i += increment;
        }
    }
