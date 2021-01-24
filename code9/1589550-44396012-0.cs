	interface IDbContext<T> where T : class
	{
		IDbSet<T> Set { get; }
	}
	// Context implement generic Interface
	class DbContextItem1 : IDbContext<Item1>
	{
		IDbSet<Item1> Set { get; private set; }
        override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Logic to get relevant mappings,
        }
	}
	// Technically you could also do that.
	class DbContextItem1 : IDbContext<Item1>, IDbContext<Item2>
	{
		IDbSet<Item1> IDbContext<Item1>.Set { get; }
		IDbSet<Item2> IDbContext<Item2>.Set { get; }
        override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Logic to get relevant mappings,
        }
	}
	// Generic context.
	class DbContextGeneric<T> : IDbContext<T>
	{
		IDbSet<T> Set { get; private set; }
		
		override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			// Logic to get relevant mappings based on T.
		}
	}
