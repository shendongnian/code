    public static IEnumerable<IEnumerable<Point>> GetShroderPaths(int n)
    {
        return getPaths(ImmutableStack<Point>.Empty.Push(default(Point)));
        IEnumerable<IEnumerable<Point>> getPaths(ImmutableStack<Point> path)
        {
            if (path.Count == 2 * n)
            {
                if (path.Peek().Y == 0)
                {
                    yield return path;
                }
            }
            else
            {
                var previous = path.FirstOrDefault();
                var next = previous.AdvanceOne();
                if (Point.CanStepUp(path) &&
                    previous.Y < n)
                {
                    foreach (var p in getPaths(path.Push(next.StepUpOne())))
                    {
                        yield return p;
                    }
                }
                foreach (var p in getPaths(path.Push(next)))
                {
                    yield return p;
                }
                if (Point.CanStepDown(path) &&
                    previous.Y > 0)
                {
                    foreach (var p in getPaths(path.Push(next.StepDownOne())))
                    {
                        yield return p;
                    }
                }
            }
        }
    }
