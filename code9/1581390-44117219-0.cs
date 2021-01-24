    public static List<int[]> getCardCombos(int[] values)
    {
      List<int[]> pairs = new List<int[]>();
      for (int x = 0; x < values.Length - 1; x++)
      {
        for (int y = x + 1; y < values.Length; y++)
        {
          int firstValue = values[x];
          int secondValue = values[y];
          // Create an array of the [x] position and [y] position of listOfValues 
          int[] xAndY = { firstValue, secondValue};
          // Create another array, except swap the positions {[y],[x]}
          int[] yAndX = { secondValue, firstValue };
 
          pairs.Add(xAndY);
          pairs.Add(yAndX);
          // Add both arrays to the "pairs" List
        }
      }
      return pairs;
    }
