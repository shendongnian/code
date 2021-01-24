    public static int SumAll(int[] a)
    {
        List<int> sum = new List<int>();
        int sumAll;
            
        if (a.Length == 0)
        {
            sumAll = 0;
        }
        else
        {
            sum.Add(a[0]);
            for (int i = 1; i < a.Length; i++)
            {
                sum.Add(sum[i - 1] + a[i]);
            }
            sumAll = sum[a.Length - 1];
        }
        return sumAll;
    }
