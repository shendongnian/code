    // simplest, providing that list doesn't contain null's
    for (int i = 0; i < lists.Count; ++i) {
      // since we want to compare sequecnes, we shall ensure the same order of their items
      var item = lists[i].OrderBy(x => x).ToArray();
      for (int j = lists.Count - 1; j > i; --j)
        if (item.SequenceEqual(lists[j].OrderBy(x => x)))
          lists.RemoveAt(j);
    }
