    public class RemainingIEnumerator<T> : IEnumerable<T>
    {
        public IEnumerable<T> Enumerable { get; set; }
        public int Nulls { get; set; }
        public T First { get; set; }
        public IEnumerator<T> Enumerator { get; set; }
        public IEnumerator<T> GetEnumerator()
        {
            var enumerator = Enumerator;
            if (enumerator == null)
            {
                return Enumerable.GetEnumerator();
            }
            return GetEnumerableRemaining().GetEnumerator();
        }
        private IEnumerable<T> GetEnumerableRemaining()
        {
            var enumerator = Enumerator;
            Enumerator = null;
            int nulls = Nulls;
            Nulls = 0;
            T first = First;
            First = default(T);
            for (int i = 0; i < nulls; i++)
            {
                yield return default(T);
            }
            yield return first;
            while (enumerator.MoveNext())
            {
                yield return enumerator.Current;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public static bool Is<T>(IEnumerable<T> enu, Type type, out IEnumerable<T> enu2)
    {
        IEnumerator<T> enumerator = null;
        int nulls = 0;
        try
        {
            enumerator = enu.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                if (current == null)
                {
                    nulls++;
                    continue;
                }
                enu2 = new RemainingIEnumerator<T>
                {
                    Enumerable = enu,
                    Nulls = nulls,
                    First = current,
                    Enumerator = enumerator,
                };
                enumerator = null;
                return current.GetType() == type;
            }
            // Only nulls case
            enu2 = new T[nulls];
            return false;
        }
        finally
        {
            if (enumerator != null)
            {
                enumerator.Dispose();
            }
        }
    }
