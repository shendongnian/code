    string ReplaceMacro(string value, Job job)
    {
        return Regex.Replace(value, @"{(?<exp>[^}]+)}", match => {
            var p = Expression.Parameter(typeof(Job), "job");
            var e = System.Linq.Dynamic.DynamicExpression.ParseLambda(new[] { p }, null, match.Groups["exp"].Value);
            return (e.Compile().DynamicInvoke(job) ?? "").ToString();
        });
    }
