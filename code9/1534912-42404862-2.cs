	public class Db : IDb<Summary>
	{
		public Response<Summary> Generate()
		{
			//...
			return new Response<Summary>
			{
				//...
			};
		}
	
		public Response<Summary> Execute()
		{
			return Generate();
		}
	}
	
	public interface IDb<T>
	{
		Response<T> Execute();
	}
