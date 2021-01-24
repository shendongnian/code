    public interface IValidityCheckBase<T> where T: class
	{
    	
	}
	public interface IValidityCheck<T> : IValidityCheckBase<DbSet<T>>
	{
		bool IsValid(Guid id, T entitySet);
	}
