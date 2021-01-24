	public class BaseParamClass
	{
	}
	
	public class ListHandler 
	{
		private List<IBase<BaseParamClass>> list;
	
		public ListHandler()
		{
			list = new List<IBase<BaseParamClass>>();
		}
	
		public void Register(IBase<BaseParamClass> param)
		{
			list.Add(param);
		}
	}
	
	public interface IBase<T> where T : BaseParamClass
	{
		T Param {get; }
	}
	
	public class BaseClass : IBase<BaseParamClass>
	{
		private ListHandler listHandler;
	
		public BaseParamClass Param { get; private set; }
	
		public BaseClass(ListHandler listHandler)
		{
			this.listHandler = listHandler;
			listHandler.Register(this); 
		}
	}
