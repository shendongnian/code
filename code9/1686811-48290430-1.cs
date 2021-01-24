    static class Extensions 
    {
      public static R[,] Select<T, R>(this T[,] items, Func<T, R> f) 
      {
        int d0 = items.GetLength(0);
        int d1 = items.GetLength(1);
        R[,] result = new R[d0, d1];
        for (int i0 = 0; i0 < d0; i0 += 1)
          for (int i1 = 0; i1 < d1; i1 += 1)
            result[i0, i1] = f(items[i0, i1]);
        return result;
      }
