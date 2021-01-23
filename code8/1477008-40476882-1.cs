    static void Sort(int[] array)
    {
        int min = int.MaxValue, max = int.MinValue;
        for (int i = 0; i < array.Length; i++)
        {
        }
        Dictionary<int, int> counts = new Dictionary<int, int>();
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] < min)
            {
                min = array[i];
            }
            if (array[i] > max)
            {
                max = array[i];
            }
            int count;
            // If the key is not present, count will get the default value for int, i.e. 0
            counts.TryGetValue(array[i], out count);
            counts[array[i]] = count + 1;
        }
        int k = 0;
        for (int j = max; j >= min; j--)
        {
            int count;
            if (counts.TryGetValue(j, out count))
            {
                for (int i = 0; i < count; i++)
                {
                    array[k++] = j;
                }
            }
        }
    }
