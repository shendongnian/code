    static void Main(string[] args)
    {
        int[] arr1 = { 1, 2, 3, 4, 5, 6 };
        int[] arr2 = { 3, 4 };
        int[] result = test(arr1, arr2);
    }
    static int[] test(int[] a, int[] b)
    {
        int k = 0;
        bool toAdd;
        int[] output = new int[] { };
        for (int i = 0; i < a.Length; i++)
        {
            toAdd = true;
            for (int j = 0; j < b.Length; j++)
            {
                if (a[i] == b[j])
                {
                    toAdd = false;
                    break;
                }
            }
            if (toAdd)
            {
                Array.Resize(ref output, k + 1);
                output[k] = a[i];
                k++;
            }             
        }
        return output;
    }
