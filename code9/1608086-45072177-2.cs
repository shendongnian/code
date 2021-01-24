    public static class LinqHelper
    {
        public static IEnumerable<T> Change<T>(this IEnumerable<T> source, Func<int, string, T> callback, int index, string argument)
        {
            var myList = new List<T>();
            myList.Add(callback(index, argument)); // i was passing parameter here which is not so helpful i guess !
            return myList;
        }
    }
