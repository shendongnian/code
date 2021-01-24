        public static IEnumerable<T> MixObjectsByProperty<T, U>(
            IEnumerable<T> objects, string propertyName, IEnumerable<IEnumerable<U>> groupsToMergeByProperty = null)
            where T : class
            where U : class
        {
            ...
