     public class ValidityCheck<T> : IValidityCheck<T>
    	{
    		public bool IsValid(Guid id, DbSet<T> entitySet)
    		{
    			return false;
    		}
    	}
