    public static class LinqExtentions
    {
        public static IEnumerable<T> RemoveNumberByCondition<T>(this IEnumerable<T> collection,
           Func<T, bool> predicate, 
           int numberToRemove = 1)
        {
            var count = 0;
            return collection.Where(x => predicate(x) || ++count > numberToRemove);
        }
    }
