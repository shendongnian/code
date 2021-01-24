     for (int i = 0; i < list1.Count; ++i)
        if (list1[i]) {
          if (i >= list2.Count) // do we want padding?
            list2.AddRange(new bool[i - list2.Count + 1]);
          list2[i] = true;
        }
