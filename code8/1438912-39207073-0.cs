    public Curve(int degree, params Point3D[] points)
                : this(degree, points) //want to chain to (int, IList<Point3D>) constructor
    {
    }
    public Curve(int degree, IList<Point3D> points)
    {
    }
