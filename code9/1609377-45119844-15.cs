    // Returns a list of paths of maximum length consisting of lists of coordinates.
    private List<List<Coord>> Find(int row, int col)
    {
        _visited[row, col] = true;
        var allResults = new List<List<Coord>>();
        for (int i = Math.Max(0, row - 1); i <= Math.Min(_world.GetLength(0) - 1, row + 1); i++) {
            for (int j = Math.Max(0, col - 1); j <= Math.Min(_world.GetLength(1) - 1, col + 1); j++) {
                if (!_visited[i, j] && _world[i, j] == 1) {
                    List<List<Coord>> result = Find(i, j);
                    allResults.AddRange(result);
                }
            }
        }
        if (allResults.Count == 0) {
            // This is an end-point of a new path. Create the new path with current coord.
            allResults.Add(new List<Coord> { new Coord(row, col) });
        } else {
            // Keep only longest results
            int maxLength = allResults.Max(p => p.Count);
            for (int i = allResults.Count - 1; i >= 0; i--) {
                if (allResults[i].Count < maxLength) {
                    allResults.RemoveAt(i);
                } else {
                    // Prepend current point to path.
                    allResults[i].Insert(0, new Coord(row, col));
                }
            }
        }
        _visited[row, col] = false;
        return allResults;
    }
