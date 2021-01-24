    public static class ListExtensions
    {
        public static void PerformActionOnSubset<T>(this IList<T> collection, int fromIndex,
            int toIndex, Action<IList<T>> action)
        {
            action(collection.Skip(fromIndex).Take(toIndex - fromIndex).ToList());
        }
    }
    myCollectionOfSomethings.PerformActionOnSubset(10, 30, myAction);
