    public class ArrowHeadConverter : IValueConverter
    {
        public object Convert(
            object value, Type targetType, object parameter, CultureInfo culture)
        {
            Geometry geometry = null;
            var points = value as IList<Point>;
            if (points != null && points.Count >= 2)
            {
                geometry = Geometry.Parse("M0,0 L5,10 -5,10Z").Clone();
                var lastPoint = points[points.Count - 1];
                var lastSegment = lastPoint - points[points.Count - 2];
                var angle = Vector.AngleBetween(new Vector(0, -1), lastSegment);
                var transform = new TransformGroup();
                transform.Children.Add(new RotateTransform(angle));
                transform.Children.Add(new TranslateTransform(lastPoint.X, lastPoint.Y));
                geometry.Transform = transform;
            }
            return geometry;
        }
        public object ConvertBack(
            object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
