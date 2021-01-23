    public class TraceXYZ : CollectionBase, ICloneable, IPointList {
        public PointPair this[int index] {
            get {
                // return new PointPair(double X, double Y);
                return new PointPair(...
            }
        }
        public object Clone() {
            // Apparently, your objects implements ICloneable, so you likely implemented Clone already
        }
        public int Count {
            get {
                // Your objects implements CollectionBase, so Count is likely already implemented
            }
        }
    }
