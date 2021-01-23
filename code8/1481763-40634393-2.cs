    public static class Ext
    {
        public static IEnumerable<TValue> RandomValues<TKey, TValue>(this IGrouping<TKey, TValue> grouping, int count)
        {
            Random rand = new Random();
            List<TValue> values = grouping.ToList();
            int size;
            while (count>0 && values.Count>0)
            {
                size = values.Count;
                var v = values[rand.Next(size)];
                values.Remove(v);
                count--;
                yield return v;
            }
        }
    }
