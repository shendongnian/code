    public static bool ContainsDuplicates(int[] a)
    {
        int count = 0;
        for (int i = 0; i < a.Length; i++)
        {
            count = 0;
            for (int j = i + 1; j < a.Length; j++)
            {
                if (a[i] == a[j])
                {
                    count++;
                }
                        
            }
            //Your value here
            if (count >= 3)
                return true;
        }
        return false;
    }
