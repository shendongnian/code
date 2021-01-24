    public struct Circle2D
    {
        private const double FullCircleAngle = 2 * Math.PI;
        public Point2D Center { get; }
        public double Radius { get; }
        public Circle2D(Point2D center, double radius)
        {
            if (radius <= 0)
                throw new ArgumentOutOfRangeException(nameof(radius));
            Center = center;
            Radius = radius;
        }
        public IEnumerable<Point2D> GetPointsOfArch(int numberOfPoints, double startAngle, double endAngle)
        {
            double normalizedEndAngle;
            if (startAngle < endAngle)
            {
                normalizedEndAngle = endAngle;
            }
            else
            {
                normalizedEndAngle = endAngle + FullCircleAngle;
            }
            var angleRange = normalizedEndAngle - startAngle;
            angleRange = angleRange > FullCircleAngle ? FullCircleAngle : angleRange;
            var step = angleRange / numberOfPoints;
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
            => GetPointsOfArch(numberOfPoints, 0, FullCircleAngle);
    }
