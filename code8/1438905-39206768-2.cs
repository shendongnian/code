    public Curve(int degree, IList<Point3D> points)
    {
        ...
    }
    public Curve(int degree, params Point3D[] points) : this(degree, points.ToList()) { }
