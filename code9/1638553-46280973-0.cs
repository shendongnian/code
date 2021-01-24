    // Dictionary of indexes to sums
    var sums = new Dictionary<int, int>();
    // Iterate your lists.
    foreach(var list in lists) {
        for (var i = 0; i < list.Count; i++) {
            // For the given index, sum up the values in the dictionary.
            if (sums.TryGetValue(i, var out value) == false) sums[i] = 0;
            sums[i] = sums[i] + list[i];
        }
    }
    
