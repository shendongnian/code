	public interface IEntity
	{
		int Id {get; set; }
		string Name {get; set; }
	}
    class Widget : IEntity 
    {
   		public int Id {get; set; }
		public string Name {get; set; }    
        public string SomeOtherProperty { get; set; }
    }
    public static SelectList  ToSelectList<T>(List<T> addlist) where T : IEntity, new ()
    {
        addlist.Insert(0, new T { Id = -1, Name = "SELECT" });
        var list = new SelectList(addlist, "Id", "Name");
        return list;
    
    }
    // In your code
    List<Widget> widgetList = new List<Widget>();
    ToSelectList(widgetList);
