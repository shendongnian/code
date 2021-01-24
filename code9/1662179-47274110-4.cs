			public IEnumerable GetDataSource(Type type)
			{
				var targetType = typeof(DbSet<>).MakeGenericType(new Type[] { type });
				
				return _db
					.GetType()
					.GetMethods()
					.Where( m => m.ReturnType == targetType)
					.Single()
					.Invoke(_db, new object[] {}) as IEnumerable;
			}
