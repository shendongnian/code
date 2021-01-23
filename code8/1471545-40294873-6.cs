	public class RepositoryLogDecorator  : IRepository
	{
		public IRepository _inner;
		
		public RepositoryLogDecorator(IRepository inner)
		{
			_inner = inner;
		}
		
		public void SaveStuff()
		{
			// log enter to method
			try
			{
				_inner.SaveStuff();
			}
			catch(Exception ex)
			{
				// log exception
			}		
			// log exit to method
		}
	}
