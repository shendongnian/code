    internal sealed class DataContextConfiguration : DbMigrationsConfiguration<DataContext>
    {
    	public DataContextConfiguration()
    	{
    		AutomaticMigrationsEnabled = true;
    		AutomaticMigrationDataLossAllowed = true;
    		ContextKey = "DataContext";
    	}
    }
