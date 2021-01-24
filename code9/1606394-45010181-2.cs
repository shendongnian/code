    public struct Circle2D
    {
        public Point2D Center { get; }
        public double Radius { get; }
        public Circle(Point2D center, double radius)
        {
            if (radius <= 0)
                throw new ArgumentOutOfRangeException(nameof(radius));
            Center = center;
            Radius = radius;
        }
        public IEnumerable<Point2D> GetPointsOfClockwiseArch(int numberOfPoints, double startAngle, double endAngle)
        {
            double normalizedEndAngle;
            if (startAngle < endAngle)
            {
                normalizedEndAngle = endAngle;
            }
            else
            {
                normalizedEndAngle = endAngle + 2 * Math.PI;
            }
            var step = (normalizedEndAngle - startAngle) / numberOfPoints;
            var currentAngle = startAngle;
            while (currentAngle <= normalizedEndAngle)
            {
                var x = Center.X + Radius * Math.Cos(currentAngle);
                var y = Center.Y + Radius * Math.Sin(currentAngle);
                yield return new Point2D(x, y);
                currentAngle += step;
            }
        }
        public IEnumerable<Point2D> GetPoints(int numberOfPoints)
            => GetPointsOfClockwiseArch(numberOfPoints, 0, 2 * Math.PI);
    }
