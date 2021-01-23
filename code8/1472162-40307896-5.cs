    class DataRowComparer : IEqualityComparer<DataRow>
    {
        private readonly List<string> _columns = new List<string>();
        public DataRowComparer(DataColumnCollection cols)
        {
            foreach (DataColumn col in cols)
            {
                _columns.Add(col.ColumnName);
            }
        }
        public bool Equals(DataRow x, DataRow y)
        {
            foreach (var column in _columns)
            {
                if (!IsEqual(x, y, column))
                    return false;
            }
            return true;
        }
        public int GetHashCode(DataRow obj)
        {
            unchecked
            {
                var hash = 19;
                foreach (var column in _columns)
                {
                    hash = hash*31 + (obj[column] == null ? 0 : obj[column].GetHashCode());
                }
                return hash;
            }
        }
        private static bool IsEqual(DataRow x, DataRow y, string column)
        {
            if (x[column] == null && y[column] == null)
                return true;
            if (x[column] == null || y[column] == null)
                return false;
            return x[column].Equals(y[column]);
        }
    }
