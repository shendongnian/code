    static int FindLargestPlinqRange(int[] arr)
    {
        return Partitioner.Create(0, arr.Length)
            .AsParallel()
            .Select(range =>
            {
                int largest = arr[0];
                for (int i = range.Item1; i < range.Item2; i++)
                    if (arr[i] > largest)
                        largest = arr[i];
                return largest;
            })
            .Max();
    }
