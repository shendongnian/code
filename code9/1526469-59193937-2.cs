    public static class IEnumerableExt {
        public static IEnumerable<T> GroupBye<T, C>(this IEnumerable<T> query, Func<IGrouping<IDictionary<string, object>, T>, C> grouping) where T : class
        {
            var cProps = typeof(C).GetProperties().Select(prop => prop.Name).ToArray();
            var columnsToGroup = typeof(T).GetProperties().Select(prop => prop.Name).Except(cProps).ToArray();
            var equalityComparer = new EqualityComparer<IDictionary<string, object>>();
            return query
                .GroupBy(x => ExpandoGroupBy(x, columnsToGroup), equalityComparer)
                .Select(x => MergeIntoNew(x, grouping, cProps));
        }
        private static IDictionary<string, object> ExpandoGroupBy<T>(T x, string[] columnsToGroup) where T : class
        {
            var groupByColumns = new System.Dynamic.ExpandoObject() as IDictionary<string, object>;
            groupByColumns.Clear();
            foreach (string column in columnsToGroup)
                groupByColumns.Add(column, typeof(T).GetProperty(column).GetValue(x, null));
            return groupByColumns;
        }
        private static T MergeIntoNew<T, C>(IGrouping<IDictionary<string, object>, T> x, Func<IGrouping<IDictionary<string, object>, T>, C> grouping, string[] cProps) where T : class
        {
            var tCtor = typeof(T).GetConstructors().Single();
            var tCtorParams = tCtor.GetParameters().Select(param => param.Name).ToArray();
            //Calling grouping lambda function
            var grouped = grouping(x);
            var paramsValues = tCtorParams.Select(p => cProps.Contains(p) ? typeof(C).GetProperty(p).GetValue(grouped, null) : x.Key[p]).ToArray();
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
