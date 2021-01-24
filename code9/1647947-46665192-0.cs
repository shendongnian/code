    public static bool ContainsDuplicates(int[] a)
    {
        for (int i = 0; i < a.Length; i++)
        {
            for (int j = i + 1; j < a.Length; j++)
            {
                for(int k = j + 1; k < a.Length; k++)
                    if (a[i] == a[j] && a[j] == a[k]) return true;
            }
        }
        return false;
    
    }
