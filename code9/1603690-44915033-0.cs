        public static void FilterSource<TKey,TElement>(IQueryable<IGrouping<TKey, TElement>> source, string filter)
        {
            //TElement is the type inside the grouping
            var properties = typeof(TElement).GetProperties().Where(x => x.PropertyType == typeof(string)) .Select(x => x.Name);
        }
