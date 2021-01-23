    public static CompassDirection? GetCompassDirectionFromUnitVector(Vector vec)
    {
        Dictionary<Vector, CompassDirection> list = new Dictionary<Vector, CompassDirection>()
        {
            {new Vector(0, 0), CompassDirection.None},
            {new Vector(0, 1), CompassDirection.North},
            {new Vector(0, -1), CompassDirection.South},
            {new Vector(1, 0), CompassDirection.East},
            {new Vector(-1, 0), CompassDirection.West},
            {new Vector(1, 1), CompassDirection.Northeast},
            {new Vector(1, -1), CompassDirection.Southeast},
            {new Vector(-1, 1), CompassDirection.Northwest},
            {new Vector(-1, -1), CompassDirection.Southwest},
        };
        if (list.ContainsKey(vec))
        {
            return list[vec];
        }
        return null;
    }
