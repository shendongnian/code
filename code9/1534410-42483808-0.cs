     public static IQueryable SelectExcept<TSource, TResult>(this IQueryable<TSource> source, List<string> excludeProperties)
        {
            var sourceType = typeof(TSource);
            var allowedSelectTypes = new Type[] { typeof(string), typeof(ValueType), typeof(object) };
            var sourceProperties = sourceType.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(p => allowedSelectTypes.Any(t => t.IsAssignableFrom(((PropertyInfo)p).PropertyType))).Select(p => ((MemberInfo)p).Name);
            var sourceFields = sourceType.GetFields(BindingFlags.Public | BindingFlags.Instance).Where(f => allowedSelectTypes.Any(t => t.IsAssignableFrom(((FieldInfo)f).FieldType))).Select(f => ((MemberInfo)f).Name);
            var selectFields = sourceProperties.Concat(sourceFields).Where(p => !excludeProperties.Contains(p)).ToArray();
            var dynamicSelect =
                    string.Format("new( {0} )",
                            string.Join(", ", selectFields));
            return selectFields.Count() > 0
                ? source.Select(dynamicSelect)
                : Enumerable.Empty<TSource>().AsQueryable<TSource>();
        }
