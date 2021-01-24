      using System.Linq;
      ...
      public static bool ContainsDuplicates(int[] a, int duplicatesAtLeast = 3) {
        if (null == a)
          throw new ArgumentNullException("a");
        
        if (duplicatesAtLeast <= 0)
          return a.Any();
        else if (duplicatesAtLeast > a.Length)
          return false;
 
        return a
          .GroupBy(item => item)
          .Any(chunk => chunk.Count() >= duplicatesAtLeast); 
      }
