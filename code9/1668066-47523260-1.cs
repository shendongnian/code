	public class ListHandler
	{
		private List<BaseClass> list;
	
		public ListHandler()
		{
			list = new List<BaseClass>();
		}
	
		public void Register<T>(BaseClass<T> param) where T : BaseParamClass
		{
			list.Add(param);
		}
	
		public BaseClass<T> Fetch<T>() where T : BaseParamClass
		{
			return list.Select(x => x as BaseClass<T>).Where(x => x != null).FirstOrDefault();
		}
	}
