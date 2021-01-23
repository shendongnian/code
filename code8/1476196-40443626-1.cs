    public static void SortOneThousandArraysAsyncWithPart() {
      var arrs = new List<int[]>(100);
      for (int i = 0; i < 100; ++i)
        arrs.Add(RandomArray(Int32.MinValue, Int32.MaxValue, 1000));
      // Let's spread the tasks between threads manually with a help of Partitioner.
      // We don't want task stealing and other optimizations: just split the
      // list between 8 (on my workstation) threads and run them
      Parallel.ForEach(Partitioner.Create(0, 100), part => {
        for (int i = part.Item1; i < part.Item2; ++i)
          Array.Sort(arrs[i]);
      });
    }
