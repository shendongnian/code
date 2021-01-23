    public static class Extensions
    {
        public static void Test()
        {
            var a = new[] { "a", "b" };
            var b = new[] { "a", "b", "c" };
            var c = new[] { "a", "b", "c", "d" };
            var d = new[] { "x", "y" };
            Console.WriteLine("b.StartsWith(a): {0}", b.StartsWith(a));
            Console.WriteLine("b.StartsWith(c): {0}", b.StartsWith(c));
            Console.WriteLine("b.StartsWith(d, x => x.Length): {0}", 
                              b.StartsWith(d, x => x.Length));
        }
        public static bool StartsWith<T>(
            this IEnumerable<T> sequence, 
            IEnumerable<T> prefixCandidate, 
            Func<T, T, bool> compare = null)
        {
            using (var eseq = sequence.GetEnumerator())
            using (var eprefix = prefixCandidate.GetEnumerator())
            {
                if (compare == null)
                {
                    compare = (x, y) => Object.Equals(x, y);
                }
                eseq.MoveNext();
                eprefix.MoveNext();
                do
                {
                    if (!compare(eseq.Current, eprefix.Current))
                        return false;
                    if (!eprefix.MoveNext())
                        return true;
                }
                while (eseq.MoveNext());
                return false;
            }
        }
        public static bool StartsWith<T, TProperty>(
            this IEnumerable<T> sequence,
            IEnumerable<T> prefixCandidate,
            Func<T, TProperty> selector)
        {
            using (var eseq = sequence.GetEnumerator())
            using (var eprefix = prefixCandidate.GetEnumerator())
            {
                eseq.MoveNext();
                eprefix.MoveNext();
                do
                {
                    if (!Object.Equals(
                            selector(eseq.Current),
                            selector(eprefix.Current)))
                    {
                        return false;
                    }
                    if (!eprefix.MoveNext())
                        return true;
                }
                while (eseq.MoveNext());
                return false;
            }
        }
    }
