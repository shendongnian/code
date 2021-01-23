	public class ParsingObjectBase
	{
		public string PropertyName { get; set; }
		public bool Active { get; set; }
		public Type ValueType { get; protected set; }
		
		public object DefVal { get; protected set; }
	}
	public class ParsingObject<T> : ParsingObjectBase
	{
		public object DefaultValue
		{
			get { return (T)DefVal; }
			set { DefVal = value; }
		}
		
		public ParsingObject()
		{
			ValueType = typeof(T);
		}
	}
	
	private readonly List<ParsingObjectBase> _listOfObjects = new List<ParsingObjectBase>();
	
	public void AddAnObject<T>(ParsingObject<T> item)
	{
		_listOfObjects.Add(item);
	}
	
	public void Parse()
	{
		foreach(var item in _listOfObjects.Where(w=>w.Active))
		{
			DoSomething(item); //do what exactly?
		}
	}
