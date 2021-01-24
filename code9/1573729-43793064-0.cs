    private static Dictionary<double, double> results = new Dictionary<double, double>();
    static double f(double n)
    {
        if (results.ContainsKey(n)) return results[n];
        if (n > 1)
        {
            var value = f(n - 3) + (9 * (f(n / 5) * f(n / 5))) + (2 * f(n - 7))
                        + ((n * n * n * n) / 2);
            results.Add(n, value);
            return value;
        }
        else
        {
            results.Add(n, 4);
            return 4;
        }
    }
