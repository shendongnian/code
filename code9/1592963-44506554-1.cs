    public static class ListExtensions
    {
        public static IList<T> Shuffle<T>(this IList<T> list, Random random)
        {
            for (var i = list.Count; i > 1; i -= 1)
            {
                var j = random.Next(i); 
                var temp = list[j];
                list[j] = list[i - 1];
                list[i - 1] = temp;
            }
            return list;
        }
    }
