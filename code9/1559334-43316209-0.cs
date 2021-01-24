	public static Func<T, Dictionary<string, object>> GetToDict<T>(){
		var getters = typeof(T)
			.GetProperties(BindingFlags.Public | BindingFlags.Instance)
			.ToDictionary(p => p, p => {
				var param = Expression.Parameter(typeof(T));
				return Expression.Lambda<Func<T, object>>(Expression.Convert(Expression.MakeMemberAccess(param, p), typeof(object)), param).Compile();
			});
		return i => getters.ToDictionary(x => x.Key.Name, x => x.Value(i));
	}
