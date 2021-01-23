    class ConsoleGeometrySink : IGeometrySink110
    {
        public void SetSrid(int srid)
        {
            Console.WriteLine($"SetSrid(srid: {srid})");
        }
        public void BeginGeometry(OpenGisGeometryType type)
        {
            Console.WriteLine($"BeginGeometry(type: {type})");
        }
        public void BeginFigure(double x, double y, double? z, double? m)
        {
            Console.WriteLine($"BeginFigure(x: {x}, y: {y}, z: {z}, m: {m})");
        }
        public void AddCircularArc(double x1, double y1, double? z1, double? m1,
                                   double x2, double y2, double? z2, double? m2)
        {
            Console.WriteLine($"AddCircularArc(x1: {x1}, y1: {y1}, z1: {z1}, m1: {m1}, " + 
                                             $"x2: {x2}, y2: {y2}, z2: {z2}, m2: {m2})");
        }
        public void AddLine(double x, double y, double? z, double? m)
        {
            Console.WriteLine($"AddLine(x: {x}, y: {y}, z: {z}, m: {m})");
        }
        public void EndFigure()
        {
            Console.WriteLine($"EndFigure()");
        }
        public void EndGeometry()
        {
            WriteLine($"EndGeometry()");
        }
    }
