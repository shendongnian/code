        private static int RoundAmount(int amount, int[] denoms, bool roundUp)
        {
            Stack<int> st = new Stack<int>(denoms);
            HashSet<int> hs = new HashSet<int>(denoms);
            while (st.Count > 0)
            {
                int v1 = st.Pop();
                foreach (int v2 in hs.ToArray())
                    if (v2 < amount)
                    {
                        int val = v1 + v2;
                        if (hs.Add(val) && val < amount)
                            st.Push(val);
                    }
            }
            int retval = roundUp ? int.MaxValue : int.MinValue;
            foreach (int v in hs)
                if (roundUp)
                {
                    if (v < retval && v >= amount)
                        retval = v;
                }
                else
                {
                    if (v > retval && v <= amount)
                        retval = v;
                }
            return retval;
        }
