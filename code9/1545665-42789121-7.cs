    public static class DynamicLinqTools
    {
        private static ConcurrentDictionary<Type, Func<object, object[]>> Converters = new ConcurrentDictionary<Type, Func<object, object[]>>();
        public static IQueryable SimpleSelect(this IQueryable query, string[] fields)
        {
            // With a little luck, "anonymizing" the field names we should 
            // reduce the number of types created!
            // new (field1 as Item1, field2 as Item2)
            return query.Select(string.Format("new ({0})", string.Join(", ", fields.Select((x, ix) => string.Format("{0} as Item{1}", x, ix + 1)))));
        }
        public static IEnumerable<object[]> ToObjectArray(this IQueryable query)
        {
            Func<object, object[]> converter;
            Converters.TryGetValue(query.ElementType, out converter);
            if (converter == null)
            {
                var row = Expression.Parameter(typeof(object), "row");
                // ElementType row2;
                var row2 = Expression.Variable(query.ElementType, "row2");
                // (ElementType)row;
                var cast = Expression.Convert(row, query.ElementType);
                // row2 = (ElementType)row;
                var assign = Expression.Assign(row2, cast);
                var properties = query.ElementType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(x => x.CanRead && x.CanWrite && x.GetIndexParameters().Length == 0)
                    .ToArray();
                // (object)row2.Item1, (object)row2.Item2, ...
                var properties2 = Array.ConvertAll(properties, x => Expression.Convert(Expression.Property(row2, x), typeof(object)));
                // new object[] { row2.Item1, row2.Item2 }
                var array = Expression.NewArrayInit(typeof(object), properties2);
                // row2 = (ElementType)row; (return) new new object[] { row2.Item1, row2.Item2 }
                var body = Expression.Block(typeof(object[]), new[] { row2 }, assign, array);
                var exp = Expression.Lambda<Func<object, object[]>>(body, row);
                converter = exp.Compile();
                Converters.TryAdd(query.ElementType, converter);
            }
            foreach (var row in query)
            {
                yield return converter(row);
            }
        }
    }
