    static IEnumerable<int> FlattenZip (List<List<int>> ienum, int maxLength = int.MaxValue)
    {
      int done = 0;
      int index = 0;
      int yielded = 0;
      while (yielded <= maxLength && ienum.Any (list => index < list.Count))
        foreach (var l in ienum)
        {
          done++;
          if (index < l.Count)
          {
            // this list is big enough, we will take one out
            yielded++;
            yield return l[index];
          }
          if (yielded > maxLength)
            break; // we are done
          if (done % (ienum.Count) == 0)
            index += 1; // checked all lists, advancing index
        }
    }
    public static void Main ()
    {
      var l1 = new List<int> { 1, 2, 3, 4 };
      var l2 = new List<int> { 11, 12, 13, 14, 15, 16 };
      var l3 = new List<int> { 21, 22, 23, 24, 25, 26 };
      var l = new List<List<int>> { l1, l2, l3 };
      var zipped = FlattenZip (l, 10);
      Console.WriteLine (string.Join (", ", zipped));
      Console.ReadLine ();
    }
    
 
