    public static class IEnumerableExt {
        public static IEnumerable<T> Collate<T, C>(this IEnumerable<T> query, Func<IGrouping<IDictionary<string, object>, T>, C> collate) where T : class
        {
            var tCtor = typeof(T).GetConstructors().Single();
            var tCtorParams = tCtor.GetParameters().Select(param => param.Name).ToArray();
            var cProps = typeof(C).GetProperties().Select(prop => prop.Name).ToArray();
            var columnsToGroup = typeof(T).GetProperties().Select(prop => prop.Name).Except(cProps).ToArray();
            var equalityComparer = new EqualityComparer<IDictionary<string, object>>();
            return query
                .GroupBy(x => ExpandoGroupBy(x, columnsToGroup), equalityComparer)
                .Select(x => MergeGrouped(collate, x))
                .Select(x => CreateNew<T, C>(x, tCtor, tCtorParams, cProps));
        }
        private static IDictionary<string, object> ExpandoGroupBy<T>(T x, string[] columnsToGroup) where T : class
        {
            var groupByColumns = new System.Dynamic.ExpandoObject();
            ((IDictionary<string, object>)groupByColumns).Clear();
            foreach (string column in columnsToGroup)
                ((IDictionary<string, object>)groupByColumns).Add(column, typeof(T).GetProperty(column).GetValue(x, null));
            return groupByColumns;
        }
        private static IDictionary<string, object> MergeGrouped<T, C>(Func<IGrouping<IDictionary<string, object>, T>, C> collate, IGrouping<IDictionary<string, object>, T> x) where T : class
        {
            x.Key.Add("_grp", collate(x));
            return x.Key;
        }
        private static T CreateNew<T, C>(IDictionary<string, object> x, System.Reflection.ConstructorInfo tCtor, IEnumerable<string> tCtorParams, string[] cProps) where T : class
        {
            var paramsValues = tCtorParams.Select(p => cProps.Contains(p) ? typeof(C).GetProperty(p).GetValue((C)x["_grp"], null) : x[p]).ToArray();
            return (T)tCtor.Invoke(paramsValues);
        }
        private class EqualityComparer<T> : IEqualityComparer<T>
        {
            public bool Equals(T x, T y)
            {
                var xDict = x as IDictionary<string, object>;
                var yDict = y as IDictionary<string, object>;
                if (xDict.Count != yDict.Count)
                    return false;
                if (xDict.Keys.Except(yDict.Keys).Any())
                    return false;
                if (yDict.Keys.Except(xDict.Keys).Any())
                    return false;
                foreach (var pair in xDict)
                    if (pair.Value == null && yDict[pair.Key] == null)
                        continue;
                    else if (pair.Value == null || !pair.Value.Equals(yDict[pair.Key]))
                        return false;
                return true;
            }
            public int GetHashCode(T obj)
            {
                return obj.ToString().GetHashCode();
            }
        }
    }
