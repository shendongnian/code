         Install-Package System.Linq.Dynamic -Version 1.0.7 
		string ReplaceMacro(string value, object @object)
		{
			return Regex.Replace(value, @"{(?<exp>.+?)}", 
			match => {
				var p = Expression.Parameter(@object.GetType(), @object.GetType().Name);				
				var e = System.Linq.Dynamic.DynamicExpression.ParseLambda(new[] { p }, null, match.Groups["exp"].Value);
				return (e.Compile().DynamicInvoke(@object) ?? "").ToString();
			});
		}
