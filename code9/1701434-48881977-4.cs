    public class SortTerm<T> 
    {
        public System.Func<T, System.IComparable> Sort;
        public SortDirection Direction;
        public SortTerm(System.Func<T, System.IComparable> sorter, SortDirection direction)
        {
            this.Sort = sorter;
            this.Direction = direction;
        }
        public SortTerm(System.Func<T, System.IComparable> sorter)
            : this(sorter, SortDirection.Ascending)
        { }
        public static SortTerm<T> Create<TKey>(System.Func<T, TKey> sorter, SortDirection direction)
            where TKey : System.IComparable
        {
            // return new SortTerm<T>((System.Func<T, System.IComparable>)(object)sorter, direction);
            return new SortTerm<T>(delegate (T x) {
                TKey ret = sorter(x);
                return (System.IComparable)ret;
            }, direction);
        } // End Constructor 
        public static SortTerm<T> Create<TKey>(System.Func<T, TKey> sorter)
            where TKey : System.IComparable
        {
            return Create<TKey>(sorter, SortDirection.Ascending);
        } // End Constructor 
    }
