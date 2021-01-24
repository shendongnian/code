    public class TimeSeries
    {
        private readonly SortedList<DateTime, DataPoint> internalCollection = new SortedList<DateTime, DataPoint>();
    
        public void Add(DataPoint dataPoint)
        {
            internalCollection.Add(dataPoint.Date, dataPoint);
        }
    
        public IEnumerator<DataPoint> GetEnumerator()
        {    
            foreach(var point in internalCollection)
            {
                yield return point.Value;
            }
        }
    }
