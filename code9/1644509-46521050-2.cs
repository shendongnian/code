    public void CreateBorder()
    {
        double angle = 2 * Math.PI / _count;
        _border.Clear();
        Plane plane = new Plane(Point3d.Origin, _normal);
        Vector3d vect = new Vector3d(_radius, 0.0, 0.0).TransformBy(Matrix3d.PlaneToWorld(plane));
        for (int i = 0; i < _count; i++)
        {
            _border.Add(_center + vect);
            vect = vect.TransformBy(Matrix3d.Rotation(angle, _normal, Point3d.Origin));
        }
    }
