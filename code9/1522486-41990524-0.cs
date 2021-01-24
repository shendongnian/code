    public static class EnumerableExtensions
    {
        public static IEnumerable<SelectListItem> ToSelectList<T>(
           this IEnumerable<T> collection,
           Func<T, object> textSelector,
           Func<T, object> valueSelector)
        {
            // null checking omitted for brevity
            foreach (var item in collection)
            {
                yield return new SelectListItem()
                {
                    Text = textSelector(item) as string,
                    Value = valueSelector(item) as string
                };
            }
        }
    }
