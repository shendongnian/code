    public class SavedPointsCollection : IList<PointF> {
        protected PointF[] _values = new PointF[4];
        public PointF this[int index] {
            get
            {
                return _values[index];
            }
            set
            {
                _values[index] = value;
                //Set temporary points here
            }
        }
        //Rest of the IList implementation
    }
    public class MyRectangle
    {
        private SavedPointsCollection _savedPoints = new SavedPointsCollection();
        protected SavedPointsCollection SavedPoints
        {
            get {
                return _savedPoints;
            }
        }
    }
