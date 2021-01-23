    static int FindLargestParallelRange(int[] arr)
    {
        object locker = new object();
        int largest = arr[0];
        Parallel.ForEach(Partitioner.Create(0, arr.Length), () => arr[0], (range, loop, subtotal) =>
        {
            for (int i = range.Item1; i < range.Item2; i++)
                if (arr[i] > subtotal)
                    subtotal = arr[i];
            return subtotal;
        },
        (finalResult) =>
        {
            lock (locker)
                if (largest < finalResult)
                    largest = finalResult;
        });
        return largest;
    }
