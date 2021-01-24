	public interface IABusiness
	{
		void functionInABusiness();
	}
	public class ABusiness : IABusiness
	{
		// making the variable private readonly ensures that nothing
		// can set it after the constructor does (thus it can never be null)
		private readonly IADataAccess aDataAccess;
		public ABusiness(IADataAccess aDataAccessParam)
		{
			// Guard clause ensures you cannot set this.aDataAccess to null
			if (aDataAccessParam == null)
				throw new ArgumentNullException(nameof(aDataAccessParam));
			this.aDataAccess=aDataAccessParam;
		}
		
		public void functionInABusiness()
		{
			// Do something with aDataAccess
		}
	}
