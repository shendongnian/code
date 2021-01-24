    public static void Set(int[] array, int index, int N)
    {
        if (index == N)
        {
            foreach (var item in array)
                Console.Write(item.ToString());
            Console.Write(Environment.NewLine);
            return;
        }
        for (int i = 1; i < N; i++)
        {
            array[index] = i;
            Set(array, index + 1, N);
        }
    }
