	public class Foo
	{
		public int Id { get; set; }
		public int Bar { get; set; }
		public int Bat { get; set; }
		public string Name { get; set; }
	}
	public class FooDupeCheckModel
	{
		public int Bar { get; set; }
		public int Bat { get; set; }
	}
	static void Main(string[] args)
	{
		var models = new FooDupeCheckModel[]
		{
			new FooDupeCheckModel() { Bar = 1, Bat = 2 },
			new FooDupeCheckModel() { Bar = 1, Bat = 3 }
		};
		var comparison = getComparison<Foo, FooDupeCheckModel>(
			models,
			compare((Foo f) => f.Bar, (FooDupeCheckModel f) => f.Bar),
			compare((Foo f) => f.Bat, (FooDupeCheckModel f) => f.Bat)
		);
		IQueryable<Foo> foos = new Foo[]
		{
			new Foo() { Bar = 1, Bat = 1 },
			new Foo() { Bar = 1, Bat = 2 },
			new Foo() { Bar = 1, Bat = 3 },
			new Foo() { Bar = 1, Bat = 4 }
		}.AsQueryable();
		var query = foos.Where(comparison);
		var results = query.ToArray();
	}
	private class PropertyComparison
	{
		public PropertyInfo FromProperty { get; set; }
		public PropertyInfo ToProperty { get; set; }
	}
	private static PropertyComparison compare<TFrom, TFromValue, TTo, TToValue>(
		Expression<Func<TFrom, TFromValue>> fromAccessor, 
		Expression<Func<TTo, TToValue>> toAccessor)
	{
		MemberExpression fromMemberAccessor = (MemberExpression)fromAccessor.Body;
		PropertyInfo fromProperty = (PropertyInfo)fromMemberAccessor.Member;
		MemberExpression toMemberAccessor = (MemberExpression)toAccessor.Body;
		PropertyInfo toProperty = (PropertyInfo)toMemberAccessor.Member;
		return new PropertyComparison() { FromProperty = fromProperty, ToProperty = toProperty };
	}
	private static Expression<Func<TFrom, bool>> getComparison<TFrom, TTo>(
		IEnumerable<TTo> models, 
		params PropertyComparison[] comparisons)
	{
		ParameterExpression pe = Expression.Parameter(typeof(TFrom), "f");
		if (!models.Any() || !comparisons.Any())
		{
			return Expression.Lambda<Func<TFrom, bool>>(Expression.Constant(true), pe);
		}
		var ands = models.Select(m =>
		{
			var equals = comparisons.Select(p =>
			{
				PropertyInfo fromProperty = p.FromProperty;
				PropertyInfo toProperty = p.ToProperty;
				object value = toProperty.GetValue(m);
				Expression fromValue = Expression.Property(pe, fromProperty);
				Expression toValue = Expression.Constant(value);
				Expression equal = Expression.Equal(fromValue, toValue);
				return equal;
			}).ToArray();
			var and = equals.First();
			foreach (var equal in equals.Skip(1))
			{
				and = Expression.AndAlso(and, equal);
			}
			return and;
		}).ToArray();
		Expression ors = ands.First();
		foreach (Expression and in ands.Skip(1))
		{
			ors = Expression.OrElse(ors, and);
		}
		return Expression.Lambda<Func<TFrom, bool>>(ors, pe);
	}
