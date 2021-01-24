        public static IEnumerable<T> InterleaveObjectsByProperty<T, U>(
            IEnumerable<T> objects, string propertyName, IEnumerable<IEnumerable<U>> groupsToMergeByProperty = null)
            where T : class
            where U : class
        {
            ...
