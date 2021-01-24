    static IEnumerable<int> FlattenZip (List<List<int>> ienum, int maxLength = int.MaxValue)
    {
      int done = 0;
      int index = 0;
      while (done <= maxLength)
        foreach (var l in ienum)
        {
          if (index < l.Count)
            done++; // this list is big enough, well take one out
          else
            continue; // list done for, not taking any here
          if (done > maxLength)
            break; // we are done
          yield return l[index];
          if (done % (ienum.Count) == 0)
            index += 1; // checked all lists, advancing index
        }
    }
    public static void Main ()
    {
      var l1 = new List<int> { 1, 2, 3, 4 };
      var l2 = new List<int> { 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
      var l3 = new List<int> { 21, 22, 23, 24, 25};
      var l = new List<List<int>> { l1, l2, l3 };
      var zipped = FlattenZip (l, 10);
      Console.WriteLine (string.Join (", ", zipped));
      Console.ReadLine ();
    }
