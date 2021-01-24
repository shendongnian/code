     static IEnumerable<Team> GetOrdered(IEnumerable<Team> teams)
     {
         var set = new HashSet<Team>(teams);
         var current = teams.Where(t => t.Parent == null).First();
         while (set.Count > 0)
         {
             yield return current;
             set.Remove(current);
             current = set.Where(t => t.Parent == current).First();
         }
     }
