    class IntervalSet< T, U >
        where T : IComparable<T>
    {
        public void Add ( T start, T end, ref U val )
        {
            if (start.CompareTo(end) >= 0) {
            }
        }
    }
