	public class Result
	{
		public bool Succeded { get; private set; }
		protected Result(bool succeeded)
		{
			Succeded = succeeded;
		}
	}
    public class Result<TData> : Result
	{
		public TData Data { get; private set; }
		protected Result(bool succeeded, TData data) : base(succeeded)
		{
			Data = data;
		}
	}    
