	public class BaseClass
	{
		protected ListHandler listHandler;
	
		public BaseClass(ListHandler listHandler)
		{
			this.listHandler = listHandler;
		}
	}
	
	public class BaseClass<T> : BaseClass where T : BaseParamClass
	{
	
		public T Param { get; private set; }
	
		public BaseClass(ListHandler listHandler)
			: base(listHandler)
		{
			listHandler.Register(this); // Compiles nicely! Yay!
		}
	}
