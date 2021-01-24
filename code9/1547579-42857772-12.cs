    private int[] GetRandomValues()
    {
      Random random = new Random();
      int[] values = new int[20];
      for(int i = 0; i < 20; i++)
      {
        // create random values until you found a distinct oune.
        int nextValue;
        do
        {
          nextValue = random.Next(1, 100);
        } while (ContainsValue(values, i, nextValue))
        values[i] = nextValue;
      } 
      return values;
    }
    // When adding the values to a List instead of an array, it would be
    // much easier, but need copying the vlaues to the array at the end.
    // When using the array directly, you have to know which values you
    // already generated, because it's initialized with zero.
    // This method checks wether the value is in the array within
    // the items until endIndex.
    private bool ContainsValue(int[] values, int endIndex, int valueToFind)
    {
      // simple linq way:
      // return values.Take(endIndex).Contains(valueToFind);
      // classic way:
      for(int i = 0; i < endIndex; i++)
      {
        if (values[i] = valueToFind) return true;
      }
      return false;
    }
