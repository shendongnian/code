        public static string GetFullPath<T>(Expression<Func<T>> action)
        {
            var removeBodyPath = new Regex(@"value\((.*)\).");
            var result = action.Body.ToString();
            var replaced = removeBodyPath.Replace(result, String.Empty);
            var seperatedFiltered = replaced.Split('.').Skip(1).ToArray();
            return string.Join(".", seperatedFiltered);
        }
