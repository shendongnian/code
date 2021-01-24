    public class MyDbContextContextFactoryGeneric : IDbContextFactory {
    	TDbContext IDbContextFactory.CreateDbContext<TDbContext>() {
		    return typeof(TDbContext) == typeof(MyDbContext)
		      ? new MyDbContext() as TDbContext
		      : Activator.CreateInstance<TDbContext>();
	    }
    }
