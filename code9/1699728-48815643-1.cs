    var result = new List<String>();
    var c2 = new Counter<String>();
    foreach(string item in myList)
    {
      c2.Add(item);
      if (c1.Count(item) == 1))
        result.Add(item);
      else
        result.Add($"{item} ({c2.Count(item)})");
    }
