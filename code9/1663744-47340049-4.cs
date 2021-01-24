    public class Path : List<Coordinate>
    {
        public Path() { }
        public Path(params (int x, int y)[] coordinates) =>
            AddRange(coordinates.Select(c => new Coordinate(c.x, c.y)));
    }
