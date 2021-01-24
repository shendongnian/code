    static void LeftRotation(int[] arr, int d)
    {
        int[] copy = arr.Select(val => val).ToArray();
        for(int i = 0; i < arr.Length; ++i)
        {
            int j = i - d;
            int position = j < 0 ? copy.Length + j : j;
            arr[position] = copy[i];
        }
    }
