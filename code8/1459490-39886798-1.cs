        public static IEnumerable<Room> GetRooms(this IEnumerable<Point> points)
        {
            if (points.Count() < 3)
                yield break;
            IEnumerable<Point> startCandidates = points;
            var discardedStartingPoints = Enumerable.Empty<Point>();
            while (startCandidates.Any())
            {
                var start = startCandidates.First();
                var potentialRooms = GetPaths(start, start, ImmutableStack<Point>.Empty).OrderBy(p => p.Count);
                if (potentialRooms.Any())
                {
                    var roomPath = potentialRooms.First();
                    yield return new Room(roomPath);
                    discardedStartingPoints = discardedStartingPoints.Concat(roomPath);
                }
                else
                {
                    discardedStartingPoints = discardedStartingPoints.Concat(new[] { start });
                }
                startCandidates = points.Except(discardedStartingPoints);
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
