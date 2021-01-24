    public static class Utilities
    {
        public static string GetPathOfProperty<T>(Expression<Func<T>> property)
        {
            string resultingString = string.Empty;
            var p = property.Body as MemberExpression;
            while (p != null)
            {
                resultingString = p.Member.Name + (resultingString != string.Empty ? "." : "") + resultingString;
                p = p.Expression as MemberExpression;
            }
            return resultingString;
        }
    }
