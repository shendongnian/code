	public enum Direction { North, East, South, West }
	
	// On a board which is an array the Y axis points downwards,
	// so e.g. North direction is (X: 0, Y: -1)
	Dictionary<Direction, Point> moves = new Dictionary<Direction, Point>
    {
        { Direction.North, new Point(0, -1) },
        { Direction.East,  new Point(1,  0) },
        { Direction.South, new Point(0,  1) },
        { Direction.West,  new Point(-1, 0) },
    };
	
