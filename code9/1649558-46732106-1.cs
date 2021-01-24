    public interface IValidityCheckBase<T> where T: class
	{
    	bool IsValid(Guid id, T entitySet);
	}
	public interface IValidityCheck<T> : IValidityCheckBase<DbSet<T>>
	{
	}
