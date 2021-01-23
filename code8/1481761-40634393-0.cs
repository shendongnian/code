    public static class Ext
    {
        public static IEnumerable<TValue> RandomValues<TKey, TValue>(this IGrouping<TKey, TValue> grouping, int count)
        {
            Random rand = new Random();
            List<TValue> values = grouping.ToList();
            int size = grouping.Count();
            while (count>0 && values.Count>0)
            {
                var v=values[rand.Next(size)];
                values.Remove(v);
                count--;
                yield return v;
            }
        }
    }
