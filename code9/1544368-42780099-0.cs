    public static Point3D GetPosition(this Matrix3D m)
    {
        return new Point3D
        {
            X = m.OffsetX,
            Y = m.OffsetY,
            Z = m.OffsetZ
        };
    }
