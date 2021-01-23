    public static IEnumerable<Room> GetRooms(this IEnumerable<Point> points)
    {
        if (points.Count() < 3) //need at least 3 points to build a room
            yield break;
        var startCandidates = points;
        while (startCandidates.Any())
        {
            var start = startCandidates.First();
            var potentialRooms = GetPaths(start, start, ImmutableStack<Point>.Empty).OrderBy(p => p.Count);
            if (potentialRooms.Any())
            {
                var roomPath = potentialRooms.First();
                yield return new Room(roomPath);
                startCandidates = startCandidates.Except(roomPath);
            }
            else
            {
                startCandidates = startCandidates.Except(new[] { start });
            }
        }
    }
    private static IEnumerable<ImmutableStack<Point>> GetPaths(Point start, Point current, ImmutableStack<Point> path)
    {
        if (current == start &&
            path.Count > 2) //discard backtracking
        {
            yield return path;
        }
        else if (path.Contains(current))
        {
            yield break;
        }
        else
        {
            var newPath = path.Push(current);
            foreach (var point in current.ConnectedPoints)
            {
                foreach (var p in GetPaths(start, point, newPath))
                {
                    yield return p;
                }
            }
        }
    }
