    public class Diversion : IDictionary<DateTime,int> {
        private decimal currentTotal;
        private SortedSet<DateTime> keys = new SortedSet<DateTime>();
        private Dictionary<DateTime,int> dict = new Dictionary<DateTime,int>();
        ...
        public decimal AvgVal {
            get {
                if (dict.Count == 0) throw InvalidOperationException();
                return currentTotal / dict.Count;
            }
        }
        public DateTime StartTime {
            get {
                if (dict.Count == 0) throw InvalidOperationException();
                return keys.Min;
            }
        }
    }
