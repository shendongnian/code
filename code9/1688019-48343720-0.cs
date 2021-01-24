    class TupleCompare : IComparer<Tuple<DateTime,int>> {
        public static readonly TupleCompare Instance = new TupleCompare();
        public int Compare(Tuple<DateTime,int> x, Tuple<DateTime,int> y) {
            return -x.Item1.CompareTo(y.Item1); // Note the negative here
        }
    }
