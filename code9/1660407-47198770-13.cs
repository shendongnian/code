    private static IEnumerable<Tuple<int, int>> Touching(char[,] items, 
                                                         Tuple<int, int> startAt, 
                                                         char letter = 'f') {
      if (startAt.Item1 < 0 || startAt.Item1 >= items.GetLength(0) ||
          startAt.Item2 < 0 || startAt.Item2 >= items.GetLength(1))
        yield break; // or throw ArgumentOutOfRangeException
      else if (items[startAt.Item1, startAt.Item2] != letter)
        yield break;
      Queue<Tuple<int, int>> agenda = new Queue<Tuple<int, int>>();
      HashSet<Tuple<int, int>> visited = new HashSet<Tuple<int, int>>() { startAt };
      agenda.Enqueue(startAt);
      
      while (agenda.Any()) {
        for (int i = agenda.Count - 1; i >= 0; --i) {
          var point = agenda.Dequeue();
          yield return point;
          // Manhattan: left, right, top, bottom neigbours only, no diagonal ones
          var validNeighbors = new Tuple<int, int>[] {
             new Tuple<int, int>(point.Item1 - 1, point.Item2),     // left
             new Tuple<int, int>(point.Item1 + 1, point.Item2),     // right
             new Tuple<int, int>(point.Item1, point.Item2 - 1),     // top
             new Tuple<int, int>(point.Item1, point.Item2 + 1),}    // bottom
          .Where(p => p.Item1 >= 0 && p.Item1 < items.GetLength(0)) // Within array
          .Where(p => p.Item2 >= 0 && p.Item2 < items.GetLength(1)) // Within array
          .Where(p => items[p.Item1, p.Item2] == letter)            // valid point
          .Where(p => visited.Add(p));                              // not visited 
          foreach (var p in validNeighbors)
            agenda.Enqueue(p);
        }
      }
    }
