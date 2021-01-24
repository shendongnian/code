    public static void SelectionSort(DataArray ar)
    {
        int n = ar.Length;
        for (int x = 0; x < n-1; x++)
        {
            int min_index = x;
            for (int y = x+1; y < n; y++)
            {
                if (ar[min_index] > ar[y])
                {
                    min_index = y;
                }
                ar.Swap(y, ar[x], ar[min_index]);
            }
        }
    }
