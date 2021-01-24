    static class EnumerableExtensions
    {
        public static IEnumerable<IGrouping<TKey, TSource>> SpecialGroupBy(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            TKey dontGroupKeyValue)
        {
            // Group all items according to the keySelector,
            // return all groups, except the group with the key dontGroupKeyValue
            var groups = source.GroupBy(keySelector);
            foreach (IGrouping<TKey, TSource> group in groups)
            {
                if (group.Key != dontGroupKeyValue)
                {  // return this as a group:
                   return group;
                }
                else
                {   // return every element of the group as a separate IGrouping
                    foreach (TSource element in group)
                    {
                       return Grouping.Create(dontGroupKeySelector, element)'
                    }
                 }
             }
        }
    }
