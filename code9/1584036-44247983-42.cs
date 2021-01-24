            private delegate int RoundAmountDelegate(int amount, int[] denoms, bool roundUp);
            private static int REPEAT = 100;
            private static int[] D_COUNT = { 2, 5, 10, 20, 50, 100 };
            private static int[] D_MAX = { 100, 10000, 1000000 };
            private static int[] A_MAX = { 10000, 1000000 };
            private static void testR()
            {            
    #if DEBUG
                while (true)
    #endif
                {
                    Random r = new Random();
                    long wT1 = 0; RoundAmountDelegate func1 = RoundAmount_maraca;
                    long wT2 = 0; RoundAmountDelegate func2 = RoundAmount_koray;
                    for (int i = 0; i < REPEAT; i++)
                    {
                        for (int j = 0; j < D_COUNT.Length; j++)
                        {
                            for (int k = 0; k < D_MAX.Length; k++)
                            {
                                for (int l = 0; l < A_MAX.Length; l++)
                                {
                                    int[] d = new int[D_COUNT[j]];
                                    ulong[] dl = new ulong[D_COUNT[j]];
                                    for (int m = 0; m < d.Length; m++)
                                    {
                                        d[m] = r.Next(D_MAX[k]) + 1;
                                        dl[m] = (ulong)d[m];
                                    }
                                    int a = r.Next(A_MAX[l]);
                                    ulong al = (ulong)a;
    
                                    Stopwatch w1 = Stopwatch.StartNew();
                                    int m1 = func1(a, d, false);
                                    int m2 = func1(a, d, true);
                                    w1.Stop();
                                    wT1 += w1.ElapsedMilliseconds;
    
                                    Stopwatch w2 = Stopwatch.StartNew();
                                    int k1 = func2(a, d, false);
                                    int k2 = func2(a, d, true);
                                    w2.Stop();
                                    wT2 += w2.ElapsedMilliseconds;
    
                                    if ((m1 != k1) || (m2 != k2))
                                    {
    #if !DEBUG
                                        MessageBox.Show("error");
    #else
                                        throw new Exception("something is wrong!");
    #endif
                                    }
                                }
                            }
                        }
                    }
    
                    //some results with release compile
    
                    //maraca:                       1085 msec
                    //koray(with .NET Stack<int>):   801 msec
    
                    //maraca:                       1127 msec
                    //koray(with .NET Stack<int>):   741 msec
    
                    //maraca:                        989 msec
                    //koray(with .NET Stack<int>):   736 msec
    
                    //maraca:                        962 msec
                    //koray(with .NET Stack<int>):   632 msec
    
                    //-------------------------------------------
                    //maraca:                     1045 msec
                    //koray(with custom stack):    674 msec
    
                    //maraca:                     1060 msec
                    //koray(with custom stack):    606 msec
    
                    //maraca:                     1175 msec
                    //koray(with custom stack):    711 msec
    
                    //maraca:                      878 msec
                    //koray(with custom stack):    699 msec
    
    #if !DEBUG
                    MessageBox.Show(wT1 + "  " + wT2 + "  %" + (double)wT2 / (double)wT1 * 100d);
    #endif
                }
            }
    
            #region Koray
            private static int RoundAmount_koray(int amount, int[] denoms, bool roundUp)
            {
                int[] sorted = new int[denoms.Length];
                Buffer.BlockCopy(denoms, 0, sorted, 0, sorted.Length * sizeof(int));
                Array.Sort(sorted);
                int minD = sorted[0];
                if (amount < minD)
                    return roundUp ? minD : 0;
                HashSet<int> hs = new HashSet<int>();
                for (int i = 0, count = sorted.Length; i < count; i++)
                {
                    int v = sorted[i];
                    if (v != 0)
                    {
                        if (!roundUp && v > amount)
                            break;
                        else if (hs.Add(v))
                        {
                            if (amount % v == 0)
                                return amount;
                            else
                                for (int j = i + 1; j < count; j++)
                                    if (sorted[j] != 0)
                                        if (v % sorted[j] == 0)
                                            sorted[j] = 0;
                                        else if (amount % (v + sorted[j]) == 0)
                                            return amount;
                        }
                    }
                }
                denoms = new int[hs.Count];
                int k = 0;
                foreach (var v in hs)
                    denoms[k++] = v;
    
                HashSet<int> hsOK = new HashSet<int>(denoms);
                stack st = new stack(denoms);
                //Stack<int> st = new Stack<int>(denoms);
                BitArray ba = new BitArray(amount + denoms[denoms.Length - 1] * 2 + 1);
                int minOK = roundUp ? amount : amount - minD;
                int maxOK = roundUp ? amount + minD : amount;
                while (st.Count > 0)
                {
                    int v1 = st.Pop();
                    foreach (int v2 in denoms)
                    {
                        int val = v1 + v2;
                        if (val <= maxOK)
                        {
                            if (!ba.Get(val))
                            {
                                if (amount % val == 0)
                                    return amount;
    
                                int diff = amount - val;
                                if (diff % v1 == 0 || diff % v2 == 0)
                                    return amount;
    
                                ba.Set(val, true);
                                if (val < amount)
                                    st.Push(val);
                                if (val >= minOK)
                                    hsOK.Add(val);
                            }
                        }
                        else
                            break;
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
            private sealed class stack
            {
                int[] _array;
                public int Count;
                public stack()
                {
                    this._array = new int[0];
                }
                public stack(int[] arr)
                {
                    this.Count = arr.Length;
                    this._array = new int[this.Count*2];
                    Buffer.BlockCopy(arr, 0, this._array, 0, this.Count * sizeof(int));
                }
                public void Push(int item)
                {
                    if (this.Count == this._array.Length)
                    {
                        int[] destinationArray = new int[2 * this.Count];
                        Buffer.BlockCopy(this._array, 0, destinationArray, 0, this.Count * sizeof(int));
                        this._array = destinationArray;
                    }
                    this._array[this.Count++] = item;
                }
                public int Pop()
                {
                    return this._array[--this.Count];
                }
            }
            #endregion
            #region Maraca
            private static int RoundAmount_maraca(int a, int[] d0, bool up)
            {
                int[] d = new int[d0.Length];
                Buffer.BlockCopy(d0, 0, d, 0, d.Length * sizeof(int));
                Array.Sort(d);
    
                if (a < d[0])
                    return up ? d[0] : 0;
                int count = 0;
                for (int i = 0; i < d.Length; i++)
                {
                    if (d[i] == 0)
                        continue;
                    for (int j = i + 1; j < d.Length; j++)
                        if (d[j] % d[i] == 0)
                            d[j] = 0;
                    if (d[i] > a && !up)
                        break;
                    d[count++] = d[i];
                    if (d[i] > a)
                        break;
                }
                if (count == 1)
                    return (!up ? a : (a + d[0] - 1)) / d[0] * d[0];
                int gcd = euclid(d[1], d[0]);
                for (int i = 2; i < count && gcd > 1; i++)
                    gcd = euclid(d[i], gcd);
                if (up)
                    a = (a + gcd - 1) / gcd;
                else
                    a /= gcd;
                for (int i = 0; i < count; i++)
                {
                    d[i] /= gcd;
                    if (a % d[i] == 0)
                        return a * gcd;
                }
                int best = !up ? d[count - 1] : ((a + d[0] - 1) / d[0] * d[0]);
                if (d[count - 1] > a)
                {
                    if (d[count - 1] < best)
                        best = d[count - 1];
                    count--;
                }
                var st = new Stack<int>();
                BitArray ba = new BitArray(a + 1);
                for (int i = 0; i < count; i++)
                {
                    ba.Set(d[i], true);
                    st.Push(d[i]);
                }
                while (st.Count > 0)
                {
                    int v1 = st.Pop();
                    for (int i = 0; i < count; i++)
                    {
                        int val = v1 + d[i];
                        if (val <= a && !ba.Get(val))
                        {
                            if ((a - val) % d[0] == 0)
                                return a * gcd;
                            ba.Set(val, true);
                            st.Push(val);
                            if (!up && val > best)
                                best = val;
                        }
                        else if (up && val > a && val < best)
                            best = val;
                    }
                }
                return best * gcd;
            }
            private static int euclid(int a, int b)
            {
                while (b != 0)
                {
                    int h = a % b;
                    a = b;
                    b = h;
                }
                return a;
            }
            #endregion
