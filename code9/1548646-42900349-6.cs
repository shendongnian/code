    public static Tuple<int, int> FindTwoSum(IList<int> list, int sum) {
        if (list.Count < 2) {
            return null;
        }
        
        // Hint 2: A dictionary can be used to store pre-calculated values,
        // this may allow a solution with O(N) complexity.
        var indexByValue = new Dictionary<int, int>();
        for (var i = 0; i < list.Count; i++) {
            var value = list[i];
            // ensure that the values used as keys are unique
            // this is OK because we only have to return any tuple matching the sum,
            // therefore we can ignore any duplicate values
            if (!indexByValue.ContainsKey(value)) {
                indexByValue.Add(value, i);
            }
        }
        
        for (var j = 0; j < list.Count; j++) {
            var remainder = sum - list[j];
            if (indexByValue.ContainsKey(remainder)) {
                return new Tuple<int, int> (j, indexByValue[remainder]);
            }
        }
        
        return null;
    }
