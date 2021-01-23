    class DataRowComparer : IEqualityComparer<DataRow>
    {
        private readonly List<string> _columns = new List<string>();
        public Comparer(DataColumnCollection cols)
        {
            foreach (DataColumn col in cols)
            {
                _columns.Add(col.ColumnName);
            }
        }
        public bool Equals(DataRow x, DataRow y)
        {
            return _columns.Aggregate(true, (current, c) => current & x[c].Equals(y[c]));
        }
        public int GetHashCode(DataRow obj)
        {
            unchecked
            {
                return _columns.Aggregate(19, (current, c) => current*31 + (obj[c] == null ? 0 : obj[c].GetHashCode()));
            }
        }
    }
