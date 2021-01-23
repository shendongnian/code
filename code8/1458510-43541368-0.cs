    public static class DbSetMocking
	{
		#region methods
		public static IReturnsResult<TContext> ReturnsDbSet<TEntity, TContext>( this IReturns<TContext, DbSet<TEntity>> setup, ICollection<TEntity> entities, Func<object[], TEntity> find = null )
			where TEntity : class where TContext : DbContext
		{
			return setup.Returns( CreateMockSet( entities, find ).Object );
		}
		private static Mock<DbSet<T>> CreateMockSet<T>( ICollection<T> data, Func<object[], T> find )
			where T : class
		{
			var queryableData = data.AsQueryable();
			var mockSet = new Mock<DbSet<T>>();
			mockSet.As<IQueryable<T>>().Setup( m => m.Provider ).Returns( queryableData.Provider );
			mockSet.As<IQueryable<T>>().Setup( m => m.Expression ).Returns( queryableData.Expression );
			mockSet.As<IQueryable<T>>().Setup( m => m.ElementType ).Returns( queryableData.ElementType );
			mockSet.As<IQueryable<T>>().Setup( m => m.GetEnumerator() ).Returns( queryableData.GetEnumerator() );
			mockSet.SetupData( data, find );
			return mockSet;
		}
		#endregion
	}
