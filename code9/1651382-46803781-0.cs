        public int CompareTo(ValueTuple<T1, T2, T3> other)
        {
            int c = Comparer<T1>.Default.Compare(Item1, other.Item1);
            if (c != 0) return c;
            c = Comparer<T2>.Default.Compare(Item2, other.Item2);
            if (c != 0) return c;
            return Comparer<T3>.Default.Compare(Item3, other.Item3);
        }
