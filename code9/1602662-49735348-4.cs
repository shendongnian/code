    using NetTopologySuite.Geometries;
    
    namespace GeoTest2.Data
    {
        public static class GeopgraphyFactory
        {
            public static Point CreatePoint(byte[] wkb)
            {
                var reader = new NetTopologySuite.IO.WKBReader();
                var val = reader.Read(wkb);
                return val as Point;
            }
    
            public static byte[] PointAsWkb(Point point)
            {
                var writer = new NetTopologySuite.IO.WKBWriter();
                return writer.Write(point);
            }
    
        }
    }
