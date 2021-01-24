    public static class Helper
    {
       public static IEnumerable<IEnumerable<int>> Unique(this IEnumerable<IEnumerable<int>> source)
       {
          var list = new List<List<int>>(); // sorted reference list.
    
          foreach (var toCompare in source)
          {
             var toComp = toCompare.OrderBy(x => x).ToList(); // prevent multiple enumerations.
             if (!list.Any(item => toComp.SequenceEqual(item)))
             {
                list.Add(toComp);
                yield return toCompare; // return the unsorted one!
             }
          }
       }
    }
