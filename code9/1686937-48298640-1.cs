	public interface IBBusiness
	{
		void function();
	}
	public class BBusiness : IBBusiness
	{
		private readonly IBDataAccess bDataAccess;
		private readonly IABusiness aBusiness;
		public BBusiness(IBDataAccess bDataAccessParam, IABusiness aBusinessParam)
		{
			if (bDataAccessParam == null)
				throw new ArgumentNullException(nameof(bDataAccessParam));
			if (aBusinessParam == null)
				throw new ArgumentNullException(nameof(aBusinessParam));
			this.bDataAccess=bDataAccessParam;
			this.aBusiness=aBusinessParam;
		}
		public function()
		{
			this.aBusiness.functionInABusiness();
            // Do something else...
		}
	}
