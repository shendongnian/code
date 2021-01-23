        public static List<SelectListItem> ToSelectListItems<T>(this IEnumerable<T> collection, Func<T, object> textSelector, Func<T, object> valueSelector, string emptyText = "- Choose-",
            string emptyValue = null)
        {
            var result = new List<SelectListItem>();
            if (collection != null)
            {
                var items = collection
                    .Select(x => new SelectListItem
                    {
                        Text = textSelector(x)?.ToString(),
                        Value = valueSelector(x)?.ToString()
                    })
                    .ToList();
                result.AddRange(items);
            }
            if (emptyText != null)
            {
                result.Insert(0, new SelectListItem { Text = emptyText, Value = emptyValue ?? string.Empty });
            }
            return result;
        }
