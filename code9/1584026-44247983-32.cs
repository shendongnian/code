    private static int RoundAmount(int amount, int[] denoms, bool roundUp)
    {
        Stack<int> st = new Stack<int>(denoms);
        BitArray ba = new BitArray(amount + denoms.Max() * 2 + 1);
        HashSet<int> hsOK = new HashSet<int>(denoms);
        int minOK = amount - denoms.Min();
        while (st.Count > 0)
        {
            int v1 = st.Pop();
            foreach (int v2 in denoms)
            {
                int val = v1 + v2;
                if (!ba.Get(val))
                {
                    ba.Set(val, true);
                    if (val < amount)
                        st.Push(val);
                    if (val >= minOK)
                        hsOK.Add(val);
                }
            }
        }
        if (!roundUp)
        {
            int retval = 0;
            foreach (int v in hsOK)
                if (v > retval && v <= amount)
                    retval = v;
            return retval;
        }
        else
        {
            int retval = int.MaxValue;
            foreach (int v in hsOK)
                if (v < retval && v >= amount)
                    retval = v;
            return retval;
        }
    }
