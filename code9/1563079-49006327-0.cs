        public class CustomHTMLHelperUtilities
        {
        // Method to Get the Property Name
        internal static string PropertyName<T, TResult>(Expression<Func<T, TResult>> expression)
         {
            switch (expression.Body.NodeType)
            {
                case ExpressionType.MemberAccess:
                    var memberExpression = expression.Body as MemberExpression;
                    return memberExpression.Member.Name;
                default:
                    return string.Empty;
            }
         }
         // Method to split the camel case
         internal static string SplitCamelCase(string camelCaseString)
         {
            string output = System.Text.RegularExpressions.Regex.Replace(
                camelCaseString,
                "([A-Z])",
                " $1",
                RegexOptions.Compiled).Trim();
            return output;
         }
        }
