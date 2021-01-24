    public class TimeSeries : IEnumerable<DataPoint>
    {
        private readonly SortedList<DateTime, DataPoint> internalCollection = new SortedList<DateTime, DataPoint>();
        public void Add(DataPoint dataPoint)
        {
            internalCollection.Add(dataPoint.Date, dataPoint);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public IEnumerator<DataPoint> GetEnumerator()
        {
            return internalCollection.Select(e => e.Value).GetEnumerator();
        }
    }
