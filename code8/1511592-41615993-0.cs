    public class SomeType
    {
        public int Id { get; set; }
        public SomeTypeType Type { get; set; }
        public DateTime Time { get; set; }
        public T Object { get; set; }
    }
    
    public class SomeType<T> : SomeType
    {
        public T Object { get; set; }
    	
    	public SomeType() { }
    	public SomeType(SomeType someType, T obj)
    	{
    		this.Id = someType.Id;
    		...
    		this.Object = obj;
    	}
    }
    
    var someType = _connection.Query<SomeType>("SELECT Id, Type, Time FROM table");
    var obj = new Foo();
    var specialisedSomeType = new SomeType<Foo>(someType, obj);
