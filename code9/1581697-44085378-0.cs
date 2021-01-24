    static void Main(string[] args)
    {
        var list = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
        foreach (var b in Batch(list))
        {
            foreach (var n in b)
                Console.Write(n + " ");
            Console.WriteLine();
        }
    }
    static IEnumerable<IList<int>> Batch(IList<int> list)
    {
        for (int i = 0; i < list.Count; i += 2)
        {
            var batch = new List<int>();
            for (int j = i; j < i + 3; j++)
                if (j < list.Count)
                    batch.Add(list[j]);
            int count = batch.Count;
            for (int j = 0; j < 3 - count; j++)
                batch.Add(list[j]);
            yield return batch;
        }
    }
