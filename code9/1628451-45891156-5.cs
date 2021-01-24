    public static int SumAll(int[] a)
    {
        if (a == null) return 0;
        int sumAll = 0;
        for (int i = 0; i < a.Length; i++)
        {
            sumAll += a[i];
        }
        return sumAll;
    }
