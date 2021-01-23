    #region sorting logic
    /// <summary>
    /// Maintains a collection of sorting maps for all used number bases.
    /// </summary>
    private static readonly Dictionary<int, int[]> _sortingTable = new Dictionary<int, int[]>();
    private static readonly object _sortingLock = new object();
    /// <summary>
    /// Compute the sorting key for a given multiple.
    /// </summary>
    /// <param name="radix">Radix or base.</param>
    /// <param name="multiple">Multiple.</param>
    /// <returns>Sorting key.</returns>
    public static int ComputeSortingKey(int radix, long multiple)
    {
      if (radix < 2)
        throw new ArgumentException("Radix may not be less than 2.");
      if (multiple == 0)
        return int.MinValue; // multiple=0 always needs to be sorted first, so pick the smallest possible key.
      int[] map;
      if (!_sortingTable.TryGetValue(radix, out map))
        lock (_sortingLock)
        {
          map = new int[radix];
          map[0] = -1; // Multiples of the radix are sorted first.
          int key = 0;
          HashSet<int> occupancy = new HashSet<int> { 0, radix };
          HashSet<int> collection = new HashSet<int>(1.ArrayTo(radix)); // (ArrayTo is an extension method in this project)
          while (collection.Count > 0)
          {
            int maxValue = 0;
            int maxDistance = 0;
            foreach (int value in collection)
            {
              int distance = int.MaxValue;
              foreach (int existingValue in occupancy)
                distance = Math.Min(distance, Math.Abs(existingValue - value));
              if (distance > maxDistance)
              {
                maxDistance = distance;
                maxValue = value;
              }
            }
            collection.Remove(maxValue);
            occupancy.Add(maxValue);
            map[maxValue] = key++;
          }
          _sortingTable.Remove(radix); // Just in case of a race-condition.
          _sortingTable.Add(radix, map);
        }
      long offset = multiple % radix;
      if (offset != 0)
        if (multiple < 0)
          offset = radix - (Math.Abs(multiple) % radix);
      return map[(int)offset];
    }
    #endregion
