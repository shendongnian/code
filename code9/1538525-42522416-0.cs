    IEnumerable<int[]> GenPolys(int n)
    {
        int[] a = new int[n];
        a[0] = 1;
        bool ok = true;
        while (ok)
        {
            yield return a;
            ok = false;
            for (int i = 1; i < n; i++)
            {
                if (a[i] == 0)
                {
                    a[i] = 1;
                    break;
                }
                else
                {
                    a[i] = 0;
                }
            }
        }
    }
