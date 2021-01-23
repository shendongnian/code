    public static class CollectionsHandling
    {
        /// <summary>
        /// Merge collections to one by index
        /// </summary>
        /// <typeparam name="T">Type of collection elements</typeparam>
        /// <param name="collections">Merging Collections</param>
        /// <returns>New collection {firsts items, second items...}</returns>
        public static IEnumerable<T> Merge<T>(params IEnumerable<T>[] collections)
        {
            // Max length of sent collections
            var maxLength = 0;
            // Enumerators of all collections
            var enumerators = new List<IEnumerator<T>>();
            foreach (var item in collections)
            {
                maxLength = Math.Max(item.Count(), maxLength);
                if(collections.Any())
                    enumerators.Add(item.GetEnumerator());
            }
            // Set enumerators to first item
            enumerators.ForEach(e => e.MoveNext());
            var result = new List<T>();
            for (int i = 0; i < maxLength; i++)
            {
                // Add elements to result collection
                enumerators.ForEach(e => result.Add(e.Current));
                // Remobve enumerators, in which no longer have elements
                enumerators = enumerators.Where(e => e.MoveNext()).ToList();
            }
            return result;
        }
    }
