	public static void Save<T, TProperty>(this IMongoCollection<T> collection, T item, Expression<Func<T, TProperty>> idFunc) where TProperty : class
	{
		var id = idFunc.Compile()(item);
		if (id == null)
		{
			collection.InsertOne(item);
		}
		else
		{
			var expression = Expression.Lambda<Func<T, bool>>(Expression.Equal(idFunc.Body, Expression.Constant(id, typeof(TProperty))), idFunc.Parameters);
			collection.ReplaceOne(expression, item);
		}
	}
