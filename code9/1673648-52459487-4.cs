    public static class AuditableExtensions
    {
    	public static DbContextOptionsBuilder AddAudit(this DbContextOptionsBuilder optionsBuilder)
    	{
    		optionsBuilder.ReplaceService<ICommandBatchPreparer, Internal.AuditableCommandBatchPreparer>();
    		return optionsBuilder;
    	}
    }
