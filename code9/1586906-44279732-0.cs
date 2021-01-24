    private static IEnumerable<T> CombinatorOrAnd<T>(IEnumerable<IEnumerable<T>> sources, 
                                                     IEnumerable<string> actions) {
      List<IEnumerable<T>> orList = new List<IEnumerable<T>>();
      // First, do all ANDs
      bool isFirst = true;
      IEnumerable<T> temp = null;
      using (var en = actions.GetEnumerator()) {
        foreach (var argument in sources) {
          if (isFirst) {
            temp = argument;
            isFirst = false;
            continue;
          }
          en.MoveNext();
          if (en.Current == "AND")
            temp = temp.Intersect(argument);
          else {
            orList.Add(temp);
            temp = argument;
          }
        }
      }
      orList.Add(temp);
      // Finally, perform all ORs 
      return orList.Aggregate((s, a) => s.Union(a));
    }
