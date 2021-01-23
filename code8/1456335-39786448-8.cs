    private static IEnumerable<int> Approximations(IEnumerable<int> values, int target) {
      int sum = 0;
      bool first = true; // we have to take at least one item
      foreach (var item in values) {
        if (sum + item < target || first) {
          first = false;
          sum += item;
        }
        else {
          if (sum + item - target < target - sum) {
            yield return sum + item; // better to take the item
            sum = 0;
            first = true;
          }
          else {
            yield return sum; // better to leave the item
            sum = item;
          }
        }
      }
      if (first) // nothing has been taken
        yield break; 
      yield return sum;
    }
