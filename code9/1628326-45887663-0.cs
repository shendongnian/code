        private static IEnumerable<T> GetDistinctValuesUsingWhere<T>(IEnumerable<T> items)
        {
            var set=new HashSet<T>();
            var capturedVariables = new CapturedVariables {set = set}
            return Where(items, capturedVariables);
        }
        IEnumerable<T> Where(IEnumerable<T> source, CapturedVariables variables)
        {
            foreach (var i in items)
            {
                if (variables.set.Add(i))
                    yield return i;
            }
        }
