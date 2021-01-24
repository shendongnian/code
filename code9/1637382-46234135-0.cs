    public abstract class PointLayer
    {
        public abstract Type Type { get;}
        public abstract string MapName { get; private set; }
        public abstract MapType MapType { get; private set; }
        public abstract Point<T> Point { get; private set; }
    }
    public class PointLayer<T> : PointLayer
    {
        #region PROPERTIES
        public override Type Type { get; }
        public override string MapName { get; private set; }
        public override MapType MapType { get; private set; }
        public override Point<T> Point { get; private set; }
        #endregion
    
        #region C'TOR
        /// <summary>
        /// Constructor creating PointLayer
        /// </summary>
        /// <param name="mapName">Map name</param>
        /// <param name="mapType">Map type</param>
        /// <param name="point">Point</param>
        public PointLayer(string mapName, MapType mapType, Point<T> point)
        {
            MapName = mapName;
            Point = point;
            MapType = mapType;
        }
        #endregion
    }
