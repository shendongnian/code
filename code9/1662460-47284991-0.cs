    public static void NormSort<T>(IList<T> input)
    {
        int n = input.Count;
        var comparer = Comparer<T>.Default;
        for (int i = 0; i < n - 2; i++)
        {
            for (int j = 0; j < n - 1; j++)
            {
                T x = input[i], y = input[j];
                if (comparer.Compare(x, y) > 0)
                {
                    input[i] = y;
                    input[j] = x;
                }
            }
        }
    }
