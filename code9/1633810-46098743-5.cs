    public static IEnumerable<int> Numbers()
    {
        int[] inc = {1, 2, 4, 4, 8, 8, 8, 8};
        for (int n = 3; n <= 144; n += inc[n / 20])
            yield return n;
    }
