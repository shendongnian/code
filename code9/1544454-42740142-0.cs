    public static int search(int lem, int[] a)
    {
        int j = -1;
        for (int i = 0; i < a.Length; i++) 
        {
            if (lem == a[i])
            {
                j = i;
            }
        }
        return j; 
    }
