    var c2 = new Counter<String>();
    // It's a bad practice to mutate a list in a foreach, so
    // we'll be sticklers and use a for.
    for (int i = 0; i < myList.Count; i = i + 1)
    {
      var item = myList[i];
      c2.Add(item);
      if (c1.Count(item) != 1))
        myList[i] = $"{item} ({c2.Count(item)})";
    }
