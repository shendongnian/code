    public struct Interval<T> where T: IComparable<T>
    {
        public T LowerBound { get; }
        public T UpperBound { get; }
        public Interval(T lowerBound, T upperBound)
        {
            Debug.Assert(upperBound.CompareTo(lowerBound) > 0);
            LowerBound = lowerBound;
            UpperBound = upperBound;
        }
        public static bool AreOverlapping(Interval<T> first, Interval<T> second) => 
            first.UpperBound.CompareTo(second.LowerBound) > 0 &&
            second.UpperBound.CompareTo(first.LowerBound) > 0;
        public static Interval<T> Union(Interval<T> first, Interval<T> second)
        {
            Debug.Assert(AreOverlapping(first, second));
            return new Interval<T>(Min(first.LowerBound, second.LowerBound),
                                   Max(first.UpperBound, second.UpperBound));
        }
        public override string ToString() => $"[{LowerBound}, {UpperBound}]";
        private static T Min(T t1, T t2)
        {
            if (t1.CompareTo(t2) <= 0)
                return t1;
            return t2;
        }
        private static T Max(T t1, T t2)
        {
            if (t1.CompareTo(t2) >= 0)
                return t1;
            return t2;
        }
    }
