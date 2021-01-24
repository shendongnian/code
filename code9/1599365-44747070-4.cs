    public static class Extensions
    {
        public static int IndexOfIgnoring<T> (this IEnumerable<T> collection, T indexOf, T toIgnore) =>
            collection.Where (arg => !Equals (arg, toIgnore)).ToList ().IndexOf (indexOf);
        public static int GetRealIndexOfIgnoring<T> (this IEnumerable<T> collection, int indexIgnored, T toIgnore)
            => collection.Select ((t, i) => new Tuple<T, int> (t, i)).Where (arg => !Equals (arg.Item1, toIgnore)).
                          ToList () [indexIgnored].Item2;
        public static IEnumerable<T> SetAtIndexOfIgnoring<T> (this IEnumerable<T> collection, int indexIgnored, T toIgnore, T toSet)
        {
            var enumerable = collection as IList<T> ?? collection.ToList ();
            return enumerable.Select ((t, i) => i == GetRealIndexOfIgnoring (enumerable, indexIgnored, toIgnore) ? toSet : t);
        }
    }
