    static class MyExtensions
    {
        private class UserByKeyComparer<TKey> : EqualityComparer<User>
        {
            private readonly Func<User, TKey> keySelector;
            private readonly EqualityComparer<TKey> keyComparer;
            public UserByKeyComparer(Func<User, TKey> keyFunc)
            {
                this.keySelector = keyFunc;
                this.keyComparer = EqualityComparer<TKey>.Default;
            }
            public override bool Equals(User x, User y)
            {
                return keyComparer.Equals(keySelector(x), keySelector(y));
            }
            public override int GetHashCode(User obj)
            {
                return keyComparer.GetHashCode(keySelector(obj));
            }
        }
        public static List<User> FilterDistinct<TKey>(this IEnumerable<User> source, Func<User, TKey> keySelector)
        {
            return source
                .Where(x => keySelector(x) != null && keySelector(x).ToString() != string.Empty)
                .Distinct(new UserByKeyComparer<TKey>(keySelector))
                .ToList();
        }
    }
