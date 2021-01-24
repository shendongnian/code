    public static int search(int lem, int[] a)
    {
        for (int i = a.Length - 1; i >= 0; i--) 
        {
            if (lem == a[i])
            {
                return i;
            }
        }
         return -1; 
    }
