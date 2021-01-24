	public static Func<T, Dictionary<string, object>> GetToDict<T>(){
		var getters = typeof(T)
			.GetProperties(BindingFlags.Public | BindingFlags.Instance)
			.Select(p => {
				var param = Expression.Parameter(typeof(T));
				return new KeyValuePair<PropertyInfo, Func<T, object>>(p, 
				 	Expression.Lambda<Func<T, object>>(Expression.Convert(Expression.MakeMemberAccess(param, p), typeof(object)), param).Compile());
			})
			.ToList();
		return i => getters.ToDictionary(x => x.Key.Name, x => x.Value(i));
	}
