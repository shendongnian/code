    private static int RoundAmount(int amount, int[] denoms, bool roundUp)
    {
        Queue<int> qu = new Queue<int>(denoms);
        BitArray ba = new BitArray(amount + denoms.Max() * 2 + 1);
        HashSet<int> hsOK = new HashSet<int>(denoms);
        int minOK = amount - denoms.Min();
        while (qu.Count > 0)
        {
            int v1 = qu.Dequeue();
            foreach (int v2 in denoms)
            {
                int val = v1 + v2;
                if (!ba.Get(val))
                {
                    ba.Set(val, true);
                    if (val < amount)
                        qu.Enqueue(val);
                    if (val >= minOK)
                        hsOK.Add(val);
                }
            }
        }
        int retval = roundUp ? int.MaxValue : 0;
        if (roundUp)
        {
            foreach (int v in hsOK)
                if (v < retval && v >= amount)
                    retval = v;
        }
        else
        {
            foreach (int v in hsOK)
                if (v > retval && v <= amount)
                    retval = v;
        }
        return retval;
    }
