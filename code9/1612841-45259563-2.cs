    public static class MyExtensions
    {
        public static T[] Subsequence<T>(this IEnumerable<T> arr,int startIndex, int length)
        {
            return arr.Skip(startIndex).Take(length).ToArray();
        }
    }
