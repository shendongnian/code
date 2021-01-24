    GeneralTransform3DTo2D transform = MyVisual.TransformToAncestor(MyViewport);
    MeshGeometry3D geometry = (MeshGeometry3D) ((GeometryModel3D) MyVisual.Content).Geometry;
    Rect wholeBounds = Rect.Empty;
    if (transform != null)
    {
        for (int i = 0; i < geometry.TriangleIndices.Count;)
        {
            Polygon p = new Polygon
            {
                Stroke = Brushes.Blue,
                StrokeThickness = 0.25
            };
            var tr = ((GeometryModel3D) MyVisual.Content).Transform;
            p.Points.Add(transform.Transform(tr.Transform(geometry.Positions[geometry.TriangleIndices[i++]])));
            p.Points.Add(transform.Transform(tr.Transform(geometry.Positions[geometry.TriangleIndices[i++]])));
            p.Points.Add(transform.Transform(tr.Transform(geometry.Positions[geometry.TriangleIndices[i++]])));
            foreach (Point point in p.Points)
            {
                wholeBounds.Union(point);
            }
        }
        MyRegion.Width = wholeBounds.Width;
        MyRegion.Height = wholeBounds.Height;
        MyRegion.Margin = new Thickness(wholeBounds.Left, wholeBounds.Top, 0, 0);
    }
