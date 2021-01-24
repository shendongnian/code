    public interface IPolygon
    {
        bool Contains(GeographicalPoint location);
    }
    public class Polygon : IPolygon
    {
        private readonly List<GeographicalPoint> _points;
        public Polygon(List<GeographicalPoint> points)
        {
            _points = points;
        }
        public bool Contains(GeographicalPoint location)
        {
            GeographicalPoint[] polygonPointsWithClosure = PolygonPointsWithClosure();
            int windingNumber = 0;
            for (int pointIndex = 0; pointIndex < polygonPointsWithClosure.Length - 1; pointIndex++)
            {
                Edge edge = new Edge(polygonPointsWithClosure[pointIndex], polygonPointsWithClosure[pointIndex + 1]);
                windingNumber += AscendingIntersection(location, edge);
                windingNumber -= DescendingIntersection(location, edge);
            }
            return windingNumber != 0;
        }
        private GeographicalPoint[] PolygonPointsWithClosure()
        {
            // _points should remain immutable, thus creation of a closed point set (starting point repeated)
            return new List<GeographicalPoint>(_points)
            {
                new GeographicalPoint(_points[0].Latitude, _points[0].Longitude)
            }.ToArray();
        }
        private static int AscendingIntersection(GeographicalPoint location, Edge edge)
        {
            if (!edge.AscendingRelativeTo(location)) { return 0; }
            if (!edge.LocationInRange(location, Orientation.Ascending)) {  return 0; }
            return Wind(location, edge, Position.Left);
        }
        private static int DescendingIntersection(GeographicalPoint location, Edge edge)
        {
            if (edge.AscendingRelativeTo(location)) { return 0; }
            if (!edge.LocationInRange(location, Orientation.Descending)) { return 0; }
            return Wind(location, edge, Position.Right);
        }
        private static int Wind(GeographicalPoint location, Edge edge, Position position)
        {
            if (edge.RelativePositionOf(location) != position) { return 0; }
            return 1;
        }
        private class Edge
        {
            private readonly GeographicalPoint _startPoint;
            private readonly GeographicalPoint _endPoint;
            public Edge(GeographicalPoint startPoint, GeographicalPoint endPoint)
            {
                _startPoint = startPoint;
                _endPoint = endPoint;
            }
            public Position RelativePositionOf(GeographicalPoint location)
            {
                double positionCalculation =
                    (_endPoint.Longitude - _startPoint.Longitude) * (location.Latitude - _startPoint.Latitude) -
                    (location.Longitude - _startPoint.Longitude) * (_endPoint.Latitude - _startPoint.Latitude);
                if (positionCalculation > 0) { return Position.Left; }
                if (positionCalculation < 0) { return Position.Right; }
                return Position.Center;
            }
            public bool AscendingRelativeTo(GeographicalPoint location)
            {
                return _startPoint.Latitude <= location.Latitude;
            }
            public bool LocationInRange(GeographicalPoint location, Orientation orientation)
            {
                if (orientation == Orientation.Ascending) return _endPoint.Latitude > location.Latitude;
                return _endPoint.Latitude <= location.Latitude;
            }
        }
        private enum Position
        {
            Left,
            Right,
            Center
        }
        private enum Orientation
        {
            Ascending,
            Descending
        }
    }
    public class GeographicalPoint
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public GeographicalPoint(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
