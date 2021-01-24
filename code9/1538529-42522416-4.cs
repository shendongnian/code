    IEnumerable<int[]> GenPolys(int n)
    {
        int[] a = new int[n + 1];
        a[0] = 1;
        bool ok = true;
        while (ok)
        {
            yield return a;
            ok = false;
            for (int i = 1; i < a.Length; i++)
            {
                a[i] = 1 - a[i]; // flip the ith bit
                if (a[i] == 1)
                {
                    ok = true;
                    break;
                }
            }
        }
    }
