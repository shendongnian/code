    // N - length of the array
    // K - kind of radix; items of the array will be in [1..K] range
    private static IEnumerable<int[]> Generator(int N = 4, int K = 3) {
      int[] items = Enumerable
        .Repeat(1, N)
        .ToArray();
      while (true) {
        yield return items.ToArray(); // .ToArray() : let's return a copy of the array
        if (items.All(item => item == K))
          break;
        for (int i = N - 1; i >= 0; --i)
          if (items[i] < K) {
            items[i] += 1;
            break;
          }
          else
            items[i] = 1;
      }
    }
