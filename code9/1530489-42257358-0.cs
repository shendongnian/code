    struct ArrayRow<T> // Consider implementing IEnumerable<T>
    {
      T[,] array;
      int row;
      public ArrayRow(T[,] array, int row) 
      { 
        this.array = array; 
        this.row = row;
      }
      public T this[int i]
      {
        get { return this.array[this.row, i]; }
        set { this.array[this.row, i] = value; }
      }
      public int Length 
      {
        get { return this.array.GetLength(1); }
      }
      public IEnumerable<T> Items ()
      {
        int c = this.Length;
        for (int i = 0; i < c; ++i)
          yield return this[i];
      }
    }
    static class Extensions 
    {
      public static ArrayRow<T> GetRow<T>(this T[,] array, int row)
      {
        return new ArrayRow<T>(array, row);
      }
    }
