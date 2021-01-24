        public static List<Point> GetLineCurveIntersections(
                   Point curve1, Point curve2, Point curve3, Point curve4,
                   Point lineStart, Point lineEnd)
        {
            var res = new List<Point>();
            var points = new List<Point>(new Point[] { curve1, curve2, curve3, curve4 });
            Rect rect = pointsBoundingRect(points);
            var rectData = new Tuple<Rect, List<Point>>(rect, points);
            var rectsData = new Queue<Tuple<Rect, List<Point>>>();
            rectsData.Enqueue(rectData);
            while (rectsData.Count != 0)
            {
                rectData = rectsData.Dequeue();
                rect = rectData.Item1;
                var controlPoints = rectData.Item2;
                if (!lineIntersectsRect(lineStart, lineEnd, rect))
                    continue;
                if (isRectSmallEnough(rect))
                {
                    res.Add(rect.Location);
                    continue;
                }
                var pointsLeft = controlPointsForCurveInRange(0, 0.5, controlPoints);
                var pointsRight = controlPointsForCurveInRange(0.501, 1, controlPoints);
                var rectLeft = pointsBoundingRect(pointsLeft);
                var rectRight = pointsBoundingRect(pointsRight);
                rectsData.Enqueue(new Tuple<Rect, List<Point>>(rectLeft, pointsLeft));
                rectsData.Enqueue(new Tuple<Rect, List<Point>>(rectRight, pointsRight));
            }
            return res;
        }
        static Rect pointsBoundingRect(List<Point> points)
        {
            var xMin = points[0].X;
            var yMin = points[0].Y;
            var xMax = xMin;
            var yMax = yMin;
            for (var i = 0; i < points.Count; ++i)
            {
                var x = points[i].X;
                var y = points[i].Y;
                if (x < xMin)
                    xMin = x;
                if (x > xMax)
                    xMax = x;
                if (y < yMin)
                    yMin = y;
                if (y > yMax)
                    yMax = y;
            }
            return new Rect(new Point(xMax, yMax), new Point(xMin, yMin));
        }
        static bool lineIntersectsRect(Point lineStart, Point lineEnd, Rect rect)
        {
            var lineXmin = lineStart.X;
            var lineXmax = lineEnd.X;
            if (lineXmin > lineXmax)
            {
                lineXmin = lineEnd.X;
                lineXmax = lineStart.X;
            }
            if (lineXmax > rect.BottomRight.X)
                lineXmax = rect.BottomRight.X;
            if (lineXmin < rect.Location.X)
                lineXmin = rect.Location.X;
            if (lineXmin > lineXmax)
                return false;
            var minY = lineStart.Y;
            var maxY = lineEnd.Y;
            var dx = lineEnd.X - lineStart.X;
            if (Math.Abs(dx) > 0.000001)
            {
                //line equation
                var a = (lineEnd.Y - lineStart.Y) / dx;
                var b = lineStart.Y - a * lineStart.X;
                minY = a * lineXmin + b;
                maxY = a * lineXmax + b;
            }
            if (minY > maxY)
            {
                var tmp = minY;
                minY = maxY;
                maxY = tmp;
            }
            if (maxY > rect.BottomRight.Y)
                maxY = rect.BottomRight.Y;
            if (minY < rect.Location.Y)
                minY = rect.Location.Y;
            if (minY > maxY)
                return false;
            return true;
        }
        static bool isRectSmallEnough(Rect rect)
        {
            return rect.Width * rect.Height <= 1;
        }
        static Point calculatePointForParameters(double[] parameters, List<Point> controlPoints)
        {
            //De Casteljau's algorithm
            if (parameters.Length != (controlPoints.Count - 1))
            {
                throw new Exception("Invalid input(calculate curve point)");
            }
            if (controlPoints.Count == 1)
                return controlPoints[0];
            var points = controlPoints;
            var iteration = 0;
            while (points.Count != 1)
            {
                var t = parameters[iteration];
                var newPoints = new List<Point>();
                for (var i = 1; i < points.Count; ++i)
                {
                    var x = (1 - t) * points[i - 1].X + t * points[i].X;
                    var y = (1 - t) * points[i - 1].Y + t * points[i].Y;
                    newPoints.Add(new Point(x, y));
                }
                ++iteration;
                points = newPoints;
            }
            return points[0];
        }
        static List<Point> controlPointsForCurveInRange(double tMin, double tMax, List<Point> points)
        {
            var controlPoints = new List<Point>();
            var pointsCount = points.Count;
            var parameters = new double[pointsCount - 1];
            for (var i = 0; i < pointsCount; ++i)
            {
                parameters.Fill(tMin, 0, parameters.Length - i);
                parameters.Fill(tMax, parameters.Length - i, pointsCount);
                var newPoint = calculatePointForParameters(parameters, points);
                controlPoints.Add(newPoint);
            }
            return controlPoints;
        }
    public static class Ex
    {
        public static void Fill<T>(this IList<T> list, T value, int start, int end)
        {
            end = Math.Min(list.Count, end);
            for (int i = start; i < end; ++i)
            {
                list[i] = value;
            }
        }
    }
