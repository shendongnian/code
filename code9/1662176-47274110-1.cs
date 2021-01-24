		public IEnumerable GetDataSource(Type type)
		{
			return _db
				.GetType()
				.GetMethods()
				.Where( m => m.ReturnType == typeof(DbSet<>).MakeGenericType(new Type[] {type}))
				.Single()
				.Invoke(_db, new object[] {}) as IEnumerable;
		}
