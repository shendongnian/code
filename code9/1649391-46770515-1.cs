    public class CategoryInitializer<T> : DropCreateDatabaseIfModelChanges<DataContext>
    {
    	public override void InitializeDatabase(DataContext context)
    	{
    		context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction
    			, $"ALTER DATABASE [{context.Database.Connection.Database}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
    
    		base.InitializeDatabase(context);
    		context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction
    			, $"ALTER DATABASE [{context.Database.Connection.Database}] SET MULTI_USER WITH ROLLBACK IMMEDIATE");
    	}
    
    	protected override void Seed(DataContext context)
    	{
          //Do your stuff
        }
