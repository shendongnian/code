        Point2dCollection _border = new Point2dCollection();
        Vector3d _normal;
        int _count;
        Point3d _center;
        double _radius;
        double _height;
        Plane _plane; // new Plane(Point3d.Origin, _normal)
        public void CreateBorder()
        {
            Point2d center = _center.Convert2d(_plane);
            double angle = 2 * Math.PI / _count;
            _border.Clear();
            for (int i = 0; i < _count; i++)
            {
                double a = i * angle;
                _border.Add(new Point2d(center.X + _radius * Math.Cos(a), center.Y + _radius * Math.Sin(a)));
            }
        }
        public Region CreateTopBottom(bool isBottom)
        {
            Region region = null;
            double elevation = _center.TransformBy(Matrix3d.WorldToPlane(_plane)).Z;
            using (Polyline pline = new Polyline(_border.Count))
            {
                for (int i = 0; i < _border.Count; i++)
                {
                    pline.AddVertexAt(i, _border[i], 0.0, 0.0, 0.0);
                }
                pline.Closed = true;
                pline.TransformBy(Matrix3d.PlaneToWorld(_plane));
                pline.Elevation = isBottom ? elevation : elevation + _height;
                var curves = new DBObjectCollection() { pline };
                var regions = Region.CreateFromCurves(curves);
                region = (Region)regions[0];
            }
            return region;
        }
