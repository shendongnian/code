        static T AddAll<T>(List<T> list)
        {
            if (list.Count == 0)
            {
                // It's additional small case
                return default(T);
            }
            var listParam = Expression.Parameter(typeof(List<T>));
            var propInfo = typeof(List<T>).GetProperty("Item");
            var indexes = list.Select((x, i) => Expression.MakeIndex(listParam, propInfo, new[] { Expression.Constant(i) }));
            Expression sum = indexes.First();
            foreach (var item in indexes.Skip(1))
            {
                sum = Expression.Add(sum, item);
            }
            var lambda = Expression.Lambda<Func<List<T>, T>>(sum, listParam).Compile();
            return lambda(list);
        }
