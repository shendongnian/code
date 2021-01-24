    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using NetTopologySuite;
    using NetTopologySuite.Geometries;
    
    namespace GeoTest2.Data
    {
        public class HomeTown
        {
            private byte[] _pointsWKB;
            public string Name { get; set; }
    
            public byte[] PointWkb
            {
                get => _pointsWKB;
                set
                {
                    if (GeopgraphyFactory.CreatePoint(value) != null)
                        _pointsWKB = value;
    
                    throw new NotImplementedException("How ever you wnat to handle it");
                }
            }
    
            [NotMapped]
            public Point Point
            {
                get => GeopgraphyFactory.CreatePoint(_pointsWKB);
                set => _pointsWKB = GeopgraphyFactory.PointAsWkb(value);
            }
        }
    }
